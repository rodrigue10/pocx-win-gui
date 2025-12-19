using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using PoCX.Common;

namespace PoCXMinerGUI
{
    /// <summary>
    /// Per-account configuration with quality limits and headers
    /// </summary>
    public class ChainAccount
    {
        public string Account { get; set; }
        public ulong? TargetQuality { get; set; }  // Account-specific quality limit
        public Dictionary<string, string> Headers { get; set; }

        public ChainAccount()
        {
            Headers = new Dictionary<string, string>();
        }

        public ChainAccount(string account)
        {
            Account = account;
            Headers = new Dictionary<string, string>();
        }
    }

    /// <summary>
    /// Configuration for a single mining chain/pool
    /// </summary>
    public class ChainConfig
    {
        public string Name { get; set; }
        public string BaseUrl { get; set; }
        public string ApiPath { get; set; }
        public ulong BlockTimeSeconds { get; set; }  // Block time for network capacity calculation
        public string AuthToken { get; set; }  // Optional bearer token
        public ulong? TargetQuality { get; set; }  // Chain-level quality limit
        public Dictionary<string, string> Headers { get; set; }  // Chain-level custom headers
        public List<ChainAccount> Accounts { get; set; }  // Per-account overrides
        public SubmissionMode SubmissionMode { get; set; }  // Submission mode (Wallet/Pool)

        public ChainConfig()
        {
            BlockTimeSeconds = 120; // Default 2 minutes
            Headers = new Dictionary<string, string>();
            Accounts = new List<ChainAccount>();
            SubmissionMode = SubmissionMode.Wallet; // Default to Wallet
        }

        public ChainConfig(string name, string baseUrl, string apiPath)
        {
            Name = name;
            BaseUrl = baseUrl;
            ApiPath = apiPath;
            BlockTimeSeconds = 120;
            Headers = new Dictionary<string, string>();
            Accounts = new List<ChainAccount>();
            SubmissionMode = SubmissionMode.Wallet; // Default to Wallet
        }
    }

    /// <summary>
    /// Benchmark mode options
    /// </summary>
    public enum BenchmarkMode
    {
        Disabled,
        Io,
        Cpu
    }

    /// <summary>
    /// Submission mode options
    /// </summary>
    public enum SubmissionMode
    {
        Wallet,
        Pool
    }

    /// <summary>
    /// Complete miner configuration
    /// </summary>
    public class MinerConfig
    {
        // Network settings
        public List<ChainConfig> Chains { get; set; }
        public ulong GetMiningInfoInterval { get; set; }
        public ulong Timeout { get; set; }

        // HDD settings
        public List<string> PlotDirs { get; set; }
        public bool HddUseDirectIo { get; set; }
        public long HddWakeupAfter { get; set; }
        public ulong HddReadCacheInWarps { get; set; }

        // Mining settings
        public bool EnableOnTheFlyCompression { get; set; }

        // CPU settings
        public int CpuThreads { get; set; }
        public bool CpuThreadPinning { get; set; }

        // Display settings
        public bool ShowProgress { get; set; }

        // Benchmark mode
        public BenchmarkMode Benchmark { get; set; }

        // Logging settings
        public string ConsoleLogLevel { get; set; }
        public string LogfileLogLevel { get; set; }
        public uint LogfileMaxCount { get; set; }
        public ulong LogfileMaxSize { get; set; }
        public string ConsoleLogPattern { get; set; }
        public string LogfileLogPattern { get; set; }

        public MinerConfig()
        {
            // Network defaults
            Chains = new List<ChainConfig>();
            GetMiningInfoInterval = 1000;
            Timeout = 5000;

            // HDD defaults
            PlotDirs = new List<string>();
            HddUseDirectIo = true;
            HddWakeupAfter = 30;
            HddReadCacheInWarps = 16;

            // Mining defaults
            EnableOnTheFlyCompression = true;

            // CPU defaults
            CpuThreads = 0; // 0 = auto-detect
            CpuThreadPinning = true;

            // Display defaults
            ShowProgress = true;

            // Benchmark defaults
            Benchmark = BenchmarkMode.Disabled;

            // Logging defaults
            ConsoleLogLevel = "info";
            LogfileLogLevel = "warn";
            LogfileMaxCount = 10;
            LogfileMaxSize = 20; // MiB
            ConsoleLogPattern = "{({d(%H:%M:%S)} [{l}]):16.16} {m}{n}";
            LogfileLogPattern = "{({d(%Y-%m-%d %H:%M:%S)} [{l}]):26.26} {m}{n}";
        }
    }

    /// <summary>
    /// Event args for output received from miner
    /// </summary>
    public class MinerOutputEventArgs : EventArgs
    {
        public string Line { get; set; }
        public bool IsError { get; set; }

        public MinerOutputEventArgs(string line, bool isError)
        {
            Line = line;
            IsError = isError;
        }
    }

    /// <summary>
    /// Manages the pocx_miner subprocess
    /// </summary>
    public class MinerProcess
    {
        private Process _process;
        private string _minerExecutablePath;
        private string _configFilePath;

        public event EventHandler<MinerOutputEventArgs> OutputReceived;
        public event EventHandler<int> ProcessExited;

        public bool IsRunning
        {
            get
            {
                try
                {
                    return _process != null && !_process.HasExited;
                }
                catch
                {
                    return false;
                }
            }
        }

        public MinerProcess()
        {
            _minerExecutablePath = MinerUpdateManager.GetMinerPath();
            _configFilePath = UpdateManagerBase.GetExecutablePath("miner_config.yaml");
        }

        public MinerProcess(string minerExecutablePath, string configFilePath = null)
        {
            _minerExecutablePath = minerExecutablePath;
            _configFilePath = configFilePath ?? UpdateManagerBase.GetExecutablePath("miner_config.yaml");
        }

        /// <summary>
        /// Starts the miner with the config file specified in constructor
        /// </summary>
        public void Start()
        {
            if (IsRunning)
            {
                throw new InvalidOperationException("Miner is already running");
            }

            if (!File.Exists(_configFilePath))
            {
                throw new FileNotFoundException($"Config file not found: {_configFilePath}");
            }

            StartProcess();
        }

        /// <summary>
        /// Sets the config file path to use
        /// </summary>
        public void SetConfigPath(string configFilePath)
        {
            if (IsRunning)
            {
                throw new InvalidOperationException("Cannot change config path while miner is running");
            }

            _configFilePath = configFilePath;
        }

        /// <summary>
        /// Sets the miner executable path
        /// </summary>
        public void SetMinerPath(string minerExecutablePath)
        {
            if (IsRunning)
            {
                throw new InvalidOperationException("Cannot change miner path while miner is running");
            }

            _minerExecutablePath = minerExecutablePath;
        }

        /// <summary>
        /// Stops the miner process
        /// </summary>
        public void Stop()
        {
            try
            {
                if (_process != null && !_process.HasExited)
                {
                    _process.Kill();
                }
            }
            catch
            {
                // Process may have already exited
            }
        }

        /// <summary>
        /// Starts the miner subprocess
        /// </summary>
        private void StartProcess()
        {
            try
            {
                _process = new Process();
                _process.StartInfo.FileName = _minerExecutablePath;
                _process.StartInfo.Arguments = $"-c \"{_configFilePath}\" --line-progress";
                _process.StartInfo.UseShellExecute = false;
                _process.StartInfo.RedirectStandardOutput = true;
                _process.StartInfo.RedirectStandardError = true;
                _process.StartInfo.CreateNoWindow = true;
                _process.StartInfo.WorkingDirectory = Path.GetDirectoryName(_minerExecutablePath) ?? Environment.CurrentDirectory;

                _process.OutputDataReceived += OnOutputDataReceived;
                _process.ErrorDataReceived += OnErrorDataReceived;
                _process.EnableRaisingEvents = true;
                _process.Exited += OnProcessExited;

                _process.Start();
                _process.BeginOutputReadLine();
                _process.BeginErrorReadLine();

                Debug.WriteLine($"Started miner process: PID={_process.Id}");
            }
            catch (Exception ex)
            {
                _process = null;
                throw new Exception($"Failed to start miner: {ex.Message}", ex);
            }
        }

        /// <summary>
        /// Handles stdout from miner
        /// </summary>
        private void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                OutputReceived?.Invoke(this, new MinerOutputEventArgs(e.Data, false));
            }
        }

        /// <summary>
        /// Handles stderr from miner
        /// </summary>
        private void OnErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Data))
            {
                OutputReceived?.Invoke(this, new MinerOutputEventArgs(e.Data, true));
            }
        }

        /// <summary>
        /// Handles process exit
        /// </summary>
        private void OnProcessExited(object sender, EventArgs e)
        {
            int exitCode = -1;
            try
            {
                exitCode = _process?.ExitCode ?? -1;
            }
            catch
            {
                // Process not started or already disposed
            }
            Debug.WriteLine($"Miner process exited with code: {exitCode}");
            ProcessExited?.Invoke(this, exitCode);
        }
    }
}
