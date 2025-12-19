using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using PoCX.Common;

namespace PoCXMinerGUI
{
    /// <summary>
    /// Manages miner configuration persistence via miner_config.yaml
    /// </summary>
    public static class SettingsManager
    {
        private static readonly string DefaultConfigPath = UpdateManagerBase.GetExecutablePath("miner_config.yaml");
        private static readonly string DefaultTemplatePath = UpdateManagerBase.GetExecutablePath("default_config.yaml");

        /// <summary>
        /// Loads miner configuration from YAML file
        /// </summary>
        public static MinerConfig LoadConfig(string path = null)
        {
            path = path ?? DefaultConfigPath;

            try
            {
                bool shouldCopyFromDefault = false;

                // Check if config doesn't exist
                if (!File.Exists(path))
                {
                    shouldCopyFromDefault = true;
                    System.Diagnostics.Debug.WriteLine($"Config file not found: {path}");
                }
                // Check if config exists but is empty or very small (likely corrupted/invalid)
                else
                {
                    var fileInfo = new FileInfo(path);
                    if (fileInfo.Length < 50)  // Less than 50 bytes is definitely invalid
                    {
                        shouldCopyFromDefault = true;
                        System.Diagnostics.Debug.WriteLine($"Config file too small ({fileInfo.Length} bytes), will replace: {path}");
                    }
                }

                // Copy from default template if needed
                if (shouldCopyFromDefault)
                {
                    if (File.Exists(DefaultTemplatePath))
                    {
                        System.Diagnostics.Debug.WriteLine($"Copying default config from {DefaultTemplatePath}");
                        File.Copy(DefaultTemplatePath, path, overwrite: true);
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine($"Default template not found: {DefaultTemplatePath}, using hardcoded defaults");
                        return new MinerConfig();
                    }
                }

                var yaml = File.ReadAllText(path);
                var deserializer = new DeserializerBuilder()
                    .WithNamingConvention(UnderscoredNamingConvention.Instance)
                    .IgnoreUnmatchedProperties()
                    .Build();

                var rawConfig = deserializer.Deserialize<Dictionary<string, object>>(yaml);
                var config = new MinerConfig();

                // Parse chains (enhanced format with new fields)
                if (rawConfig.ContainsKey("chains") && rawConfig["chains"] is List<object> chainsList)
                {
                    foreach (var chainObj in chainsList)
                    {
                        if (chainObj is Dictionary<object, object> chainDict)
                        {
                            var chain = new ChainConfig
                            {
                                Name = GetStringValue(chainDict, "name"),
                                BaseUrl = GetStringValue(chainDict, "base_url"),
                                ApiPath = GetStringValue(chainDict, "api_path"),
                                BlockTimeSeconds = GetUlongValue(chainDict, "block_time_seconds", 120),
                                AuthToken = GetStringValue(chainDict, "auth_token"),
                                TargetQuality = GetNullableUlongValue(chainDict, "target_quality"),
                                SubmissionMode = GetSubmissionMode(chainDict, "submission_mode")
                            };

                            // Parse chain-level headers
                            if (chainDict.ContainsKey("headers") && chainDict["headers"] is Dictionary<object, object> headersDict)
                            {
                                foreach (var kvp in headersDict)
                                {
                                    chain.Headers[kvp.Key.ToString()] = kvp.Value?.ToString() ?? "";
                                }
                            }

                            // Parse accounts with enhanced format
                            if (chainDict.ContainsKey("accounts") && chainDict["accounts"] is List<object> accountsList)
                            {
                                foreach (var accountObj in accountsList)
                                {
                                    if (accountObj is Dictionary<object, object> accountDict)
                                    {
                                        var account = new ChainAccount
                                        {
                                            Account = GetStringValue(accountDict, "account"),
                                            TargetQuality = GetNullableUlongValue(accountDict, "target_quality")
                                        };

                                        // Parse account-level headers
                                        if (accountDict.ContainsKey("headers") && accountDict["headers"] is Dictionary<object, object> accHeadersDict)
                                        {
                                            foreach (var kvp in accHeadersDict)
                                            {
                                                account.Headers[kvp.Key.ToString()] = kvp.Value?.ToString() ?? "";
                                            }
                                        }

                                        chain.Accounts.Add(account);
                                    }
                                }
                            }

                            config.Chains.Add(chain);
                        }
                    }
                }

                // Parse plot directories
                if (rawConfig.ContainsKey("plot_dirs") && rawConfig["plot_dirs"] is List<object> dirsList)
                {
                    foreach (var dir in dirsList)
                    {
                        if (dir != null)
                        {
                            config.PlotDirs.Add(dir.ToString());
                        }
                    }
                }

                // Network settings
                if (rawConfig.ContainsKey("get_mining_info_interval"))
                    config.GetMiningInfoInterval = Convert.ToUInt64(rawConfig["get_mining_info_interval"]);
                if (rawConfig.ContainsKey("timeout"))
                    config.Timeout = Convert.ToUInt64(rawConfig["timeout"]);

                // HDD settings
                if (rawConfig.ContainsKey("hdd_use_direct_io"))
                    config.HddUseDirectIo = Convert.ToBoolean(rawConfig["hdd_use_direct_io"]);
                if (rawConfig.ContainsKey("hdd_wakeup_after"))
                    config.HddWakeupAfter = Convert.ToInt64(rawConfig["hdd_wakeup_after"]);
                if (rawConfig.ContainsKey("hdd_read_cache_in_warps"))
                    config.HddReadCacheInWarps = Convert.ToUInt64(rawConfig["hdd_read_cache_in_warps"]);

                // Mining settings
                if (rawConfig.ContainsKey("enable_on_the_fly_compression"))
                    config.EnableOnTheFlyCompression = Convert.ToBoolean(rawConfig["enable_on_the_fly_compression"]);

                // CPU settings
                if (rawConfig.ContainsKey("cpu_threads"))
                    config.CpuThreads = Convert.ToInt32(rawConfig["cpu_threads"]);
                if (rawConfig.ContainsKey("cpu_thread_pinning"))
                    config.CpuThreadPinning = Convert.ToBoolean(rawConfig["cpu_thread_pinning"]);

                // Display settings
                if (rawConfig.ContainsKey("show_progress"))
                    config.ShowProgress = Convert.ToBoolean(rawConfig["show_progress"]);

                // Benchmark
                if (rawConfig.ContainsKey("benchmark"))
                {
                    var benchmarkStr = rawConfig["benchmark"].ToString().ToLower();
                    config.Benchmark = benchmarkStr == "i/o" ? BenchmarkMode.Io :
                                      benchmarkStr == "cpu" ? BenchmarkMode.Cpu :
                                      BenchmarkMode.Disabled;
                }

                // Logging settings
                if (rawConfig.ContainsKey("console_log_level"))
                    config.ConsoleLogLevel = rawConfig["console_log_level"].ToString();
                if (rawConfig.ContainsKey("logfile_log_level"))
                    config.LogfileLogLevel = rawConfig["logfile_log_level"].ToString();
                if (rawConfig.ContainsKey("logfile_max_count"))
                    config.LogfileMaxCount = Convert.ToUInt32(rawConfig["logfile_max_count"]);
                if (rawConfig.ContainsKey("logfile_max_size"))
                    config.LogfileMaxSize = Convert.ToUInt64(rawConfig["logfile_max_size"]);
                if (rawConfig.ContainsKey("console_log_pattern"))
                    config.ConsoleLogPattern = rawConfig["console_log_pattern"].ToString();
                if (rawConfig.ContainsKey("logfile_log_pattern"))
                    config.LogfileLogPattern = rawConfig["logfile_log_pattern"].ToString();

                System.Diagnostics.Debug.WriteLine($"Loaded config from: {path}");
                return config;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading config: {ex.Message}");
                return new MinerConfig();
            }
        }

        /// <summary>
        /// Saves miner configuration to YAML file
        /// </summary>
        public static void SaveConfig(MinerConfig config, string path = null)
        {
            path = path ?? DefaultConfigPath;

            try
            {
                var yaml = GenerateYamlConfig(config);
                File.WriteAllText(path, yaml);
                System.Diagnostics.Debug.WriteLine($"Saved config to: {path}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to save config: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Generates YAML configuration string from MinerConfig
        /// </summary>
        private static string GenerateYamlConfig(MinerConfig config)
        {
            var yamlConfig = new Dictionary<string, object>();

            // Chains configuration
            var chains = new List<Dictionary<string, object>>();
            foreach (var chain in config.Chains)
            {
                var chainDict = new Dictionary<string, object>
                {
                    { "name", chain.Name },
                    { "base_url", chain.BaseUrl },
                    { "api_path", chain.ApiPath },
                    { "block_time_seconds", chain.BlockTimeSeconds },
                    { "submission_mode", chain.SubmissionMode == SubmissionMode.Pool ? "pool" : "wallet" }
                };

                // Optional: auth token
                if (!string.IsNullOrEmpty(chain.AuthToken))
                    chainDict["auth_token"] = chain.AuthToken;

                // Optional: target quality
                if (chain.TargetQuality.HasValue)
                    chainDict["target_quality"] = chain.TargetQuality.Value;

                // Optional: chain-level headers
                if (chain.Headers.Count > 0)
                    chainDict["headers"] = chain.Headers;

                // Accounts
                if (chain.Accounts.Count > 0)
                {
                    var accounts = new List<Dictionary<string, object>>();
                    foreach (var account in chain.Accounts)
                    {
                        var accDict = new Dictionary<string, object>
                        {
                            { "account", account.Account }
                        };

                        if (account.TargetQuality.HasValue)
                            accDict["target_quality"] = account.TargetQuality.Value;

                        if (account.Headers.Count > 0)
                            accDict["headers"] = account.Headers;

                        accounts.Add(accDict);
                    }
                    chainDict["accounts"] = accounts;
                }

                chains.Add(chainDict);
            }
            yamlConfig["chains"] = chains;

            // Network settings
            yamlConfig["get_mining_info_interval"] = config.GetMiningInfoInterval;
            yamlConfig["timeout"] = config.Timeout;

            // Plot directories
            yamlConfig["plot_dirs"] = config.PlotDirs;

            // HDD settings
            yamlConfig["hdd_use_direct_io"] = config.HddUseDirectIo;
            yamlConfig["hdd_wakeup_after"] = config.HddWakeupAfter;
            yamlConfig["hdd_read_cache_in_warps"] = config.HddReadCacheInWarps;

            // Mining settings
            yamlConfig["enable_on_the_fly_compression"] = config.EnableOnTheFlyCompression;

            // CPU settings
            if (config.CpuThreads > 0)
                yamlConfig["cpu_threads"] = config.CpuThreads;
            else
                yamlConfig["cpu_threads"] = 0; // Explicit 0 for auto-detect

            yamlConfig["cpu_thread_pinning"] = config.CpuThreadPinning;

            // Display settings
            yamlConfig["show_progress"] = config.ShowProgress;

            // Benchmark
            string benchmarkStr = config.Benchmark == BenchmarkMode.Io ? "I/O" :
                                 config.Benchmark == BenchmarkMode.Cpu ? "CPU" :
                                 "disabled";
            yamlConfig["benchmark"] = benchmarkStr;

            // Logging settings
            yamlConfig["console_log_level"] = config.ConsoleLogLevel;
            yamlConfig["logfile_log_level"] = config.LogfileLogLevel;
            yamlConfig["logfile_max_count"] = config.LogfileMaxCount;
            yamlConfig["logfile_max_size"] = config.LogfileMaxSize;
            yamlConfig["console_log_pattern"] = config.ConsoleLogPattern;
            yamlConfig["logfile_log_pattern"] = config.LogfileLogPattern;

            // Serialize to YAML
            var serializer = new SerializerBuilder()
                .WithNamingConvention(UnderscoredNamingConvention.Instance)
                .Build();

            return serializer.Serialize(yamlConfig);
        }

        // Helper methods for parsing
        private static string GetStringValue(Dictionary<object, object> dict, string key)
        {
            if (dict.ContainsKey(key) && dict[key] != null)
                return dict[key].ToString();
            return string.Empty;
        }

        private static ulong GetUlongValue(Dictionary<object, object> dict, string key, ulong defaultValue)
        {
            if (dict.ContainsKey(key) && dict[key] != null)
                return Convert.ToUInt64(dict[key]);
            return defaultValue;
        }

        private static ulong? GetNullableUlongValue(Dictionary<object, object> dict, string key)
        {
            if (dict.ContainsKey(key) && dict[key] != null)
                return Convert.ToUInt64(dict[key]);
            return null;
        }

        private static SubmissionMode GetSubmissionMode(Dictionary<object, object> dict, string key)
        {
            if (dict.ContainsKey(key) && dict[key] != null)
            {
                var value = dict[key].ToString().ToLower();
                return value == "pool" ? SubmissionMode.Pool : SubmissionMode.Wallet;
            }
            return SubmissionMode.Wallet; // Default
        }

        /// <summary>
        /// Loads window position and size from application settings
        /// </summary>
        public static void LoadWindowSettings(System.Windows.Forms.Form form)
        {
            try
            {
                var windowState = Properties.Settings.Default.WindowState;
                var windowLocation = Properties.Settings.Default.WindowLocation;
                var windowSize = Properties.Settings.Default.WindowSize;

                if (!windowSize.IsEmpty)
                    form.Size = windowSize;

                if (!windowLocation.IsEmpty)
                    form.Location = windowLocation;

                if (windowState != System.Windows.Forms.FormWindowState.Minimized)
                    form.WindowState = windowState;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading window settings: {ex.Message}");
            }
        }

        /// <summary>
        /// Saves window position and size to application settings
        /// </summary>
        public static void SaveWindowSettings(System.Windows.Forms.Form form)
        {
            try
            {
                Properties.Settings.Default.WindowState = form.WindowState;

                if (form.WindowState == System.Windows.Forms.FormWindowState.Normal)
                {
                    Properties.Settings.Default.WindowLocation = form.Location;
                    Properties.Settings.Default.WindowSize = form.Size;
                }
                else
                {
                    Properties.Settings.Default.WindowLocation = form.RestoreBounds.Location;
                    Properties.Settings.Default.WindowSize = form.RestoreBounds.Size;
                }

                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error saving window settings: {ex.Message}");
            }
        }

        /// <summary>
        /// Gets the config file path - always uses %LOCALAPPDATA%\PoCX for user-writable location
        /// </summary>
        public static string GetConfigPath()
        {
            // Always use LocalAppData location for configs (user-writable, no admin needed)
            // Clear any old saved path that might point to Program Files or elsewhere
            var savedPath = Properties.Settings.Default.ConfigFilePath;
            if (!string.IsNullOrEmpty(savedPath) && savedPath != DefaultConfigPath)
            {
                // Clear legacy path and save
                Properties.Settings.Default.ConfigFilePath = "";
                Properties.Settings.Default.Save();
            }

            return DefaultConfigPath;
        }

        /// <summary>
        /// Sets the config file path in application settings
        /// </summary>
        public static void SetConfigPath(string path)
        {
            Properties.Settings.Default.ConfigFilePath = path;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Loads miner executable path - always uses %LOCALAPPDATA%\PoCX for user-writable location
        /// </summary>
        public static string LoadMinerPath()
        {
            // Always use LocalAppData location for executables (user-writable, no admin needed)
            var defaultPath = MinerUpdateManager.GetMinerPath();

            // Clear any old saved path that might point to Program Files or elsewhere
            var savedPath = Properties.Settings.Default.MinerExecutablePath;
            if (!string.IsNullOrEmpty(savedPath) && savedPath != defaultPath)
            {
                Properties.Settings.Default.MinerExecutablePath = "";
                Properties.Settings.Default.Save();
            }

            return defaultPath;
        }

        /// <summary>
        /// Saves miner executable path to application settings
        /// </summary>
        public static void SaveMinerPath(string path)
        {
            Properties.Settings.Default.MinerExecutablePath = path;
            Properties.Settings.Default.Save();
        }
    }
}
