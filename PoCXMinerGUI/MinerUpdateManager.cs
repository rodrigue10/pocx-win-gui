using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Octokit;
using PoCX.Common;

namespace PoCXMinerGUI
{
    /// <summary>
    /// Miner-specific update check result
    /// </summary>
    public class MinerUpdateCheckResult : UpdateCheckResultBase
    {
        public bool IsMinerAvailable { get; set; }
        public new List<MinerReleaseInfo> AvailableReleases { get; set; }

        public MinerUpdateCheckResult()
        {
            AvailableReleases = new List<MinerReleaseInfo>();
        }
    }

    /// <summary>
    /// Miner-specific release information
    /// </summary>
    public class MinerReleaseInfo : ReleaseInfo
    {
        public bool IsMinerAvailable { get; set; }
    }

    /// <summary>
    /// Manages checking for updates and downloading miner executable from GitHub releases
    /// </summary>
    public class MinerUpdateManager : UpdateManagerBase
    {
        private const string MINER_ASSET_PATTERN = "windows-msvc.zip";
        private const string MINER_EXE_NAME = "pocx_miner.exe";
        private const string TARGET_NAME = "pocx_miner.exe";
        private const string SOURCE_CONFIG_NAME = "miner_config.yaml";  // Name in GitHub release zip
        private const string TARGET_CONFIG_NAME = "default_config.yaml"; // Name saved locally as template

        public MinerUpdateManager() : base("PoCXMinerGUI")
        {
        }

        /// <summary>
        /// Checks if miner executable is present
        /// </summary>
        public static bool IsMinerExecutablePresent()
        {
            return File.Exists(GetExecutablePath(TARGET_NAME));
        }

        /// <summary>
        /// Gets the full path to the miner executable
        /// </summary>
        public static string GetMinerPath()
        {
            return GetExecutablePath(TARGET_NAME);
        }

        /// <summary>
        /// Checks for available updates from GitHub releases
        /// </summary>
        public async Task<MinerUpdateCheckResult> CheckForUpdatesAsync()
        {
            try
            {
                var allReleases = await _githubClient.Repository.Release.GetAll(GITHUB_OWNER, GITHUB_REPO);
                _latestRelease = allReleases.FirstOrDefault();

                if (_latestRelease == null)
                {
                    throw new Exception("No releases found");
                }

                var result = new MinerUpdateCheckResult
                {
                    LatestVersion = _latestRelease.TagName,
                    CurrentVersion = GetCurrentVersion(),
                    ReleaseNotes = _latestRelease.Body,
                    PublishedAt = _latestRelease.PublishedAt?.DateTime,
                };

                result.IsMinerAvailable = _latestRelease.Assets.Any(a =>
                    a.Name.Contains(MINER_ASSET_PATTERN) && !a.Name.Contains("opencl"));

                result.UpdateAvailable = CompareVersions(result.CurrentVersion, result.LatestVersion) < 0;

                foreach (var release in allReleases)
                {
                    var releaseInfo = new MinerReleaseInfo
                    {
                        Version = release.TagName,
                        ReleaseNotes = release.Body,
                        PublishedAt = release.PublishedAt?.DateTime,
                        IsPrerelease = release.Prerelease,
                        IsMinerAvailable = release.Assets.Any(a => a.Name.Contains(MINER_ASSET_PATTERN) && !a.Name.Contains("opencl")),
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
        /// Downloads and installs the miner from latest release
        /// </summary>
        public async Task DownloadAndInstallAsync()
        {
            if (_latestRelease == null)
            {
                await CheckForUpdatesAsync();
            }

            await DownloadAndInstallAsync(null);
        }

        /// <summary>
        /// Downloads and installs the miner from a specific release
        /// </summary>
        public async Task DownloadAndInstallAsync(MinerReleaseInfo releaseInfo)
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

            await DownloadAndInstallExecutableAsync(targetRelease);
            SaveCurrentVersion(targetRelease.TagName);
        }

        /// <summary>
        /// Downloads and installs the miner executable from a given release
        /// </summary>
        private async Task DownloadAndInstallExecutableAsync(Release release)
        {
            var asset = release.Assets.FirstOrDefault(a =>
                a.Name.Contains(MINER_ASSET_PATTERN) && !a.Name.Contains("opencl"));

            if (asset == null)
            {
                throw new Exception($"Could not find {MINER_ASSET_PATTERN} asset in release {release.TagName}");
            }

            string tempZipPath = Path.Combine(Path.GetTempPath(), asset.Name);
            string tempExtractPath = Path.Combine(Path.GetTempPath(), $"pocx_extract_{Guid.NewGuid()}");

            try
            {
                await DownloadFileAsync(asset.BrowserDownloadUrl, tempZipPath, asset.Name);

                Directory.CreateDirectory(tempExtractPath);
                ZipFile.ExtractToDirectory(tempZipPath, tempExtractPath);

                string extractedMiner = Path.Combine(tempExtractPath, MINER_EXE_NAME);
                if (!File.Exists(extractedMiner))
                {
                    throw new Exception($"{MINER_EXE_NAME} not found in downloaded archive");
                }

                string targetPath = GetExecutablePath(TARGET_NAME);
                if (File.Exists(targetPath))
                {
                    string backupName = $"{targetPath}.bak";
                    if (File.Exists(backupName))
                    {
                        File.Delete(backupName);
                    }
                    File.Move(targetPath, backupName);
                }

                File.Copy(extractedMiner, targetPath, true);

                // Copy config template from release (miner_config.yaml) to local template (default_config.yaml)
                string extractedConfig = Path.Combine(tempExtractPath, SOURCE_CONFIG_NAME);
                if (File.Exists(extractedConfig))
                {
                    string configTargetPath = GetExecutablePath(TARGET_CONFIG_NAME);
                    if (File.Exists(configTargetPath))
                    {
                        string configBackupName = $"{configTargetPath}.bak";
                        if (File.Exists(configBackupName))
                        {
                            File.Delete(configBackupName);
                        }
                        File.Move(configTargetPath, configBackupName);
                    }
                    File.Copy(extractedConfig, configTargetPath, true);
                    System.Diagnostics.Debug.WriteLine($"Copied config template to: {configTargetPath}");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine($"Warning: {SOURCE_CONFIG_NAME} not found in archive at: {extractedConfig}");
                }
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
            return Properties.Settings.Default.InstalledMinerVersion ?? "unknown";
        }

        protected override void SaveCurrentVersion(string version)
        {
            Properties.Settings.Default.InstalledMinerVersion = version;
            Properties.Settings.Default.Save();
        }
    }
}
