using System;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Octokit;

namespace PoCX.Common
{
    /// <summary>
    /// Base class for update managers that download executables from GitHub releases
    /// </summary>
    public abstract class UpdateManagerBase : IDisposable
    {
        protected const string GITHUB_OWNER = "PoC-Consortium";
        protected const string GITHUB_REPO = "pocx";
        private const string POCX_FOLDER_NAME = "PoCX";

        /// <summary>
        /// Gets the directory where PoCX executables are stored (%LOCALAPPDATA%\PoCX)
        /// Creates the directory if it doesn't exist.
        /// </summary>
        public static string GetExecutablesDirectory()
        {
            string localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            string pocxDir = Path.Combine(localAppData, POCX_FOLDER_NAME);

            if (!Directory.Exists(pocxDir))
            {
                Directory.CreateDirectory(pocxDir);
            }

            return pocxDir;
        }

        /// <summary>
        /// Gets the full path to an executable in the PoCX directory
        /// </summary>
        public static string GetExecutablePath(string executableName)
        {
            return Path.Combine(GetExecutablesDirectory(), executableName);
        }

        protected readonly GitHubClient _githubClient;
        protected Release _latestRelease;
        protected bool _disposed = false;

        public event EventHandler<DownloadProgressEventArgs> DownloadProgressChanged;

        protected UpdateManagerBase(string productHeader)
        {
            _githubClient = new GitHubClient(new ProductHeaderValue(productHeader));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _disposed = true;
            }
        }

        /// <summary>
        /// Gets the currently installed version from settings
        /// </summary>
        protected abstract string GetCurrentVersion();

        /// <summary>
        /// Saves the current version to settings
        /// </summary>
        protected abstract void SaveCurrentVersion(string version);

        /// <summary>
        /// Downloads a file with progress reporting
        /// </summary>
        protected async Task DownloadFileAsync(string url, string destinationPath, string fileName)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.Timeout = TimeSpan.FromMinutes(10);

                using (var response = await httpClient.GetAsync(url, HttpCompletionOption.ResponseHeadersRead))
                {
                    response.EnsureSuccessStatusCode();

                    var totalBytes = response.Content.Headers.ContentLength ?? -1;
                    var canReportProgress = totalBytes != -1;

                    using (var contentStream = await response.Content.ReadAsStreamAsync())
                    using (var fileStream = new FileStream(destinationPath, System.IO.FileMode.Create, FileAccess.Write, FileShare.None, 8192, FileOptions.Asynchronous))
                    {
                        var buffer = new byte[8192];
                        long totalRead = 0;
                        int bytesRead;

                        while ((bytesRead = await contentStream.ReadAsync(buffer, 0, buffer.Length)) > 0)
                        {
                            await fileStream.WriteAsync(buffer, 0, bytesRead);
                            totalRead += bytesRead;

                            if (canReportProgress)
                            {
                                var progressPercentage = (int)((totalRead * 100) / totalBytes);
                                OnDownloadProgressChanged(new DownloadProgressEventArgs
                                {
                                    BytesReceived = totalRead,
                                    TotalBytes = totalBytes,
                                    ProgressPercentage = progressPercentage,
                                    FileName = fileName
                                });
                            }
                        }
                    }
                }
            }
        }

        protected virtual void OnDownloadProgressChanged(DownloadProgressEventArgs e)
        {
            DownloadProgressChanged?.Invoke(this, e);
        }

        /// <summary>
        /// Downloads and extracts a ZIP file, then copies a specific executable to target location
        /// </summary>
        protected async Task DownloadAndExtractExecutableAsync(Release release, string assetPattern, string sourceExeName, string targetPath, bool isOpenCl = false)
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

                string extractedExe = Path.Combine(tempExtractPath, sourceExeName);
                if (!File.Exists(extractedExe))
                {
                    throw new Exception($"{sourceExeName} not found in downloaded archive");
                }

                if (File.Exists(targetPath))
                {
                    string backupName = $"{targetPath}.bak";
                    if (File.Exists(backupName))
                    {
                        File.Delete(backupName);
                    }
                    File.Move(targetPath, backupName);
                }

                File.Copy(extractedExe, targetPath, true);
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

        /// <summary>
        /// Extracts a config file from a release if present
        /// </summary>
        protected void ExtractConfigFileIfPresent(string tempExtractPath, string configFileName)
        {
            string extractedConfig = Path.Combine(tempExtractPath, configFileName);
            if (File.Exists(extractedConfig))
            {
                if (File.Exists(configFileName))
                {
                    string configBackupName = $"{configFileName}.bak";
                    if (File.Exists(configBackupName))
                    {
                        File.Delete(configBackupName);
                    }
                    File.Move(configFileName, configBackupName);
                }
                File.Copy(extractedConfig, configFileName, true);
            }
        }

        /// <summary>
        /// Compares two version strings (format: v1.0.0-rc1 or v1.0.0)
        /// Returns: -1 if current less than latest, 0 if equal, 1 if current greater than latest
        /// </summary>
        protected int CompareVersions(string current, string latest)
        {
            if (current == "unknown") return -1;

            try
            {
                var currentClean = CleanVersion(current);
                var latestClean = CleanVersion(latest);

                var currentParts = currentClean.Split('.').Select(int.Parse).ToArray();
                var latestParts = latestClean.Split('.').Select(int.Parse).ToArray();

                for (int i = 0; i < Math.Min(currentParts.Length, latestParts.Length); i++)
                {
                    if (currentParts[i] < latestParts[i]) return -1;
                    if (currentParts[i] > latestParts[i]) return 1;
                }

                return currentParts.Length.CompareTo(latestParts.Length);
            }
            catch
            {
                return -1;
            }
        }

        /// <summary>
        /// Cleans version string by removing 'v' prefix and prerelease suffixes
        /// </summary>
        protected string CleanVersion(string version)
        {
            if (string.IsNullOrEmpty(version)) return "0.0.0";

            version = version.TrimStart('v', 'V');

            int dashIndex = version.IndexOf('-');
            if (dashIndex > 0)
            {
                version = version.Substring(0, dashIndex);
            }

            return version;
        }
    }
}
