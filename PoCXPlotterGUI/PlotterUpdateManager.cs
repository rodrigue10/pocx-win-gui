using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Octokit;
using PoCX.Common;

namespace PoCXPlotterGUI
{
    /// <summary>
    /// Plotter-specific update check result
    /// </summary>
    public class PlotterUpdateCheckResult : UpdateCheckResultBase
    {
        public bool IsCpuAvailable { get; set; }
        public bool IsGpuAvailable { get; set; }
        public new List<PlotterReleaseInfo> AvailableReleases { get; set; }

        public PlotterUpdateCheckResult()
        {
            AvailableReleases = new List<PlotterReleaseInfo>();
        }
    }

    /// <summary>
    /// Plotter-specific release information
    /// </summary>
    public class PlotterReleaseInfo : ReleaseInfo
    {
        public bool IsCpuAvailable { get; set; }
        public bool IsGpuAvailable { get; set; }
    }

    /// <summary>
    /// Type of executable to download
    /// </summary>
    public enum ExecutableType
    {
        CPU,
        GPU,
        Both
    }

    /// <summary>
    /// Manages checking for updates and downloading plotter executables from GitHub releases
    /// </summary>
    public class PlotterUpdateManager : UpdateManagerBase
    {
        private const string CPU_ASSET_PATTERN = "windows-msvc.zip";
        private const string GPU_ASSET_PATTERN = "windows-msvc-opencl.zip";
        private const string PLOTTER_EXE_NAME = "pocx_plotter.exe";
        private const string CPU_TARGET_NAME = "pocx_plotter_cpu.exe";
        private const string GPU_TARGET_NAME = "pocx_plotter_gpu.exe";

        public PlotterUpdateManager() : base("PoCXPlotterGUI")
        {
        }

        /// <summary>
        /// Checks if executables are present
        /// </summary>
        public static bool AreExecutablesPresent(out bool cpuMissing, out bool gpuMissing)
        {
            cpuMissing = !File.Exists(GetExecutablePath(CPU_TARGET_NAME));
            gpuMissing = !File.Exists(GetExecutablePath(GPU_TARGET_NAME));
            return !cpuMissing && !gpuMissing;
        }

        /// <summary>
        /// Gets the full path to the CPU plotter executable
        /// </summary>
        public static string GetCpuPlotterPath()
        {
            return GetExecutablePath(CPU_TARGET_NAME);
        }

        /// <summary>
        /// Gets the full path to the GPU plotter executable
        /// </summary>
        public static string GetGpuPlotterPath()
        {
            return GetExecutablePath(GPU_TARGET_NAME);
        }

        /// <summary>
        /// Checks for available updates from GitHub releases
        /// </summary>
        public async Task<PlotterUpdateCheckResult> CheckForUpdatesAsync()
        {
            try
            {
                var allReleases = await _githubClient.Repository.Release.GetAll(GITHUB_OWNER, GITHUB_REPO);
                _latestRelease = allReleases.FirstOrDefault();

                if (_latestRelease == null)
                {
                    throw new Exception("No releases found");
                }

                var result = new PlotterUpdateCheckResult
                {
                    LatestVersion = _latestRelease.TagName,
                    CurrentVersion = GetCurrentVersion(),
                    ReleaseNotes = _latestRelease.Body,
                    PublishedAt = _latestRelease.PublishedAt?.DateTime,
                };

                result.IsCpuAvailable = _latestRelease.Assets.Any(a =>
                    a.Name.Contains(CPU_ASSET_PATTERN) && !a.Name.Contains("opencl"));
                result.IsGpuAvailable = _latestRelease.Assets.Any(a =>
                    a.Name.Contains(GPU_ASSET_PATTERN));

                result.UpdateAvailable = CompareVersions(result.CurrentVersion, result.LatestVersion) < 0;

                foreach (var release in allReleases)
                {
                    var releaseInfo = new PlotterReleaseInfo
                    {
                        Version = release.TagName,
                        ReleaseNotes = release.Body,
                        PublishedAt = release.PublishedAt?.DateTime,
                        IsPrerelease = release.Prerelease,
                        IsCpuAvailable = release.Assets.Any(a => a.Name.Contains(CPU_ASSET_PATTERN) && !a.Name.Contains("opencl")),
                        IsGpuAvailable = release.Assets.Any(a => a.Name.Contains(GPU_ASSET_PATTERN)),
                        GitHubRelease = release
                    };
                    result.AvailableReleases.Add(releaseInfo);
                }

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to check for updates: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Downloads and installs the specified executable type(s) from latest release
        /// </summary>
        public async Task DownloadAndInstallAsync(ExecutableType type)
        {
            if (_latestRelease == null)
            {
                await CheckForUpdatesAsync();
            }

            await DownloadAndInstallAsync(type, null);
        }

        /// <summary>
        /// Downloads and installs the specified executable type(s) from a specific release
        /// </summary>
        public async Task DownloadAndInstallAsync(ExecutableType type, PlotterReleaseInfo releaseInfo)
        {
            Release targetRelease;

            if (releaseInfo != null)
            {
                targetRelease = releaseInfo.GitHubRelease;
            }
            else
            {
                if (_latestRelease == null)
                {
                    await CheckForUpdatesAsync();
                }
                targetRelease = _latestRelease;
            }

            if (type == ExecutableType.CPU || type == ExecutableType.Both)
            {
                await DownloadAndInstallExecutableAsync(targetRelease, CPU_ASSET_PATTERN, CPU_TARGET_NAME, false);
            }

            if (type == ExecutableType.GPU || type == ExecutableType.Both)
            {
                await DownloadAndInstallExecutableAsync(targetRelease, GPU_ASSET_PATTERN, GPU_TARGET_NAME, true);
            }

            SaveCurrentVersion(targetRelease.TagName);
        }

        /// <summary>
        /// Downloads and installs a specific executable from a given release
        /// </summary>
        private async Task DownloadAndInstallExecutableAsync(Release release, string assetPattern, string targetName, bool isOpenCl)
        {
            var asset = release.Assets.FirstOrDefault(a =>
                a.Name.Contains(assetPattern) && (isOpenCl ? a.Name.Contains("opencl") : !a.Name.Contains("opencl")));

            if (asset == null)
            {
                throw new Exception($"Could not find {assetPattern} asset in release {release.TagName}");
            }

            string tempZipPath = Path.Combine(Path.GetTempPath(), asset.Name);
            string tempExtractPath = Path.Combine(Path.GetTempPath(), $"pocx_extract_{Guid.NewGuid()}");

            try
            {
                await DownloadFileAsync(asset.BrowserDownloadUrl, tempZipPath, asset.Name);

                Directory.CreateDirectory(tempExtractPath);
                ZipFile.ExtractToDirectory(tempZipPath, tempExtractPath);

                string extractedPlotter = Path.Combine(tempExtractPath, PLOTTER_EXE_NAME);
                if (!File.Exists(extractedPlotter))
                {
                    throw new Exception($"{PLOTTER_EXE_NAME} not found in downloaded archive");
                }

                string targetPath = GetExecutablePath(targetName);
                if (File.Exists(targetPath))
                {
                    string backupPath = $"{targetPath}.bak";
                    if (File.Exists(backupPath))
                    {
                        File.Delete(backupPath);
                    }
                    File.Move(targetPath, backupPath);
                }

                File.Copy(extractedPlotter, targetPath, true);
            }
            finally
            {
                if (File.Exists(tempZipPath))
                {
                    File.Delete(tempZipPath);
                }
                if (Directory.Exists(tempExtractPath))
                {
                    Directory.Delete(tempExtractPath, true);
                }
            }
        }

        protected override string GetCurrentVersion()
        {
            return Properties.Settings.Default.InstalledPlotterVersion ?? "unknown";
        }

        protected override void SaveCurrentVersion(string version)
        {
            Properties.Settings.Default.InstalledPlotterVersion = version;
            Properties.Settings.Default.Save();
        }
    }
}
