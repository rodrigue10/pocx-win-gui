using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace PoCXPlotterGUI
{
    /// <summary>
    /// Configuration for plotting operation
    /// </summary>
    public class PlotterConfig
    {
        public string AccountAddress { get; set; }
        public decimal Warps { get; set; }
        public bool PlotMaximumSize { get; set; }
        public List<string> OutputPaths { get; set; }
        public int NumFiles { get; set; }
        public bool UseMemoryLimit { get; set; }
        public int MemoryLimitMiB { get; set; }
        public bool DirectIo { get; set; }
        public bool LowPriority { get; set; }
        public bool Benchmark { get; set; }
        public bool ZeroCopyBuffers { get; set; }
        public bool UseCustomEncounters { get; set; }
        public decimal Encounters { get; set; }
        public decimal CompressionRatio { get; set; }
        public bool UseCustomWorkGroups { get; set; }
        public decimal WorkGroups { get; set; }
        public List<DeviceConfig> Devices { get; set; }
        public bool UseOpenCl { get; set; }
        public bool UseFixedSeed { get; set; }
        public string Seed { get; set; }

        public PlotterConfig()
        {
            OutputPaths = new List<string>();
            Devices = new List<DeviceConfig>();
        }
    }

    /// <summary>
    /// Device configuration for plotting
    /// </summary>
    public class DeviceConfig
    {
        public bool IsCpu { get; set; }
        public string GpuId { get; set; }
        public int ThreadCount { get; set; }
    }

    /// <summary>
    /// Manages the plotter subprocess lifecycle
    /// </summary>
    public class PlotterProcess
    {
        private Process _process;
        private ProgressParser _progressParser;
        private AutoResetEvent _processCompleteEvent;

        public event EventHandler ProcessExited;
        public event EventHandler<HashProgressEventArgs> HashProgressUpdated;
        public event EventHandler<WriteProgressEventArgs> WriteProgressUpdated;
        public event EventHandler<OutputEventArgs> StandardOutputReceived;
        public event EventHandler<OutputEventArgs> ErrorOutputReceived;

        public bool IsRunning => _process != null && !_process.HasExited;

        /// <summary>
        /// Starts the plotting process
        /// </summary>
        public void Start(PlotterConfig config)
        {
            if (IsRunning)
                throw new InvalidOperationException("Plotter process is already running");

            _processCompleteEvent = new AutoResetEvent(false);

            // Start in background thread
            ThreadPool.QueueUserWorkItem(state =>
            {
                RunProcess(config);
                _processCompleteEvent.Set();
            });
        }

        /// <summary>
        /// Stops the plotting process
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
            catch (Exception)
            {
                // Process may have already exited
            }
        }

        /// <summary>
        /// Waits for the plotting process to complete
        /// </summary>
        public void Wait()
        {
            _processCompleteEvent?.WaitOne();
        }

        /// <summary>
        /// Runs the plotter process
        /// </summary>
        private void RunProcess(PlotterConfig config)
        {
            try
            {
                string executable = config.UseOpenCl
                    ? PlotterUpdateManager.GetGpuPlotterPath()
                    : PlotterUpdateManager.GetCpuPlotterPath();
                string arguments = BuildCommandLine(config);

                using (_process = new Process())
                {
                    _process.StartInfo = new ProcessStartInfo(executable, arguments)
                    {
                        WindowStyle = ProcessWindowStyle.Hidden,
                        RedirectStandardOutput = true,
                        RedirectStandardError = true,
                        UseShellExecute = false,
                        WorkingDirectory = Environment.CurrentDirectory,
                        CreateNoWindow = true
                    };

                    _process.EnableRaisingEvents = true;
                    _process.OutputDataReceived += OnOutputDataReceived;
                    _process.ErrorDataReceived += OnErrorDataReceived;
                    _process.Exited += OnProcessExited;

                    _process.Start();

                    // Create progress parser with process start time
                    _progressParser = new ProgressParser(_process.StartTime);
                    _progressParser.HashProgressUpdated += (s, e) => HashProgressUpdated?.Invoke(this, e);
                    _progressParser.WriteProgressUpdated += (s, e) => WriteProgressUpdated?.Invoke(this, e);
                    _progressParser.StandardOutputReceived += (s, e) => StandardOutputReceived?.Invoke(this, e);
                    _progressParser.ErrorOutputReceived += (s, e) => ErrorOutputReceived?.Invoke(this, e);

                    _process.BeginOutputReadLine();
                    _process.BeginErrorReadLine();
                    _process.WaitForExit();
                }
            }
            catch (Exception ex)
            {
                // Log process start failure - raise error event
                ErrorOutputReceived?.Invoke(this, new OutputEventArgs { Data = $"Failed to start plotter: {ex.Message}" });
            }
        }

        /// <summary>
        /// Handles process standard output
        /// </summary>
        private void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null && _progressParser != null)
            {
                _progressParser.ParseStandardOutput(e.Data);
            }
        }

        /// <summary>
        /// Handles process error output
        /// </summary>
        private void OnErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null && _progressParser != null)
            {
                _progressParser.ParseErrorOutput(e.Data);
            }
        }

        /// <summary>
        /// Handles process exit
        /// </summary>
        private void OnProcessExited(object sender, EventArgs e)
        {
            ProcessExited?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Gets the full command line that would be executed (executable + arguments)
        /// </summary>
        public static string GetFullCommandLine(PlotterConfig config)
        {
            string executable = config.UseOpenCl
                ? PlotterUpdateManager.GetGpuPlotterPath()
                : PlotterUpdateManager.GetCpuPlotterPath();
            string arguments = BuildCommandLine(config);
            return $"{executable} {arguments}";
        }

        /// <summary>
        /// Builds command-line arguments for the plotter
        /// </summary>
        private static string BuildCommandLine(PlotterConfig config)
        {
            var args = new List<string>();

            // Required arguments
            args.Add($"-i {config.AccountAddress}");

            // Only add -w parameter if not plotting maximum size
            if (!config.PlotMaximumSize)
            {
                args.Add($"-w {config.Warps}");
            }

            // Output paths
            foreach (var path in config.OutputPaths)
            {
                args.Add($"-p {path}");
            }

            args.Add($"-n {config.NumFiles}");

            // Fixed seed
            if (config.UseFixedSeed && !string.IsNullOrEmpty(config.Seed))
                args.Add($"-s {config.Seed}");

            // Optional arguments
            if (config.UseMemoryLimit)
                args.Add($"-m {config.MemoryLimitMiB}MiB");

            if (config.UseCustomEncounters)
                args.Add($"-e {config.Encounters}");

            if (!config.DirectIo)
                args.Add("-d");

            if (config.LowPriority)
                args.Add("-l");

            if (config.Benchmark)
                args.Add("-b");

            if (config.ZeroCopyBuffers && config.UseOpenCl)
                args.Add("-z");

            if (config.UseCustomWorkGroups && config.UseOpenCl)
                args.Add($"-k {config.WorkGroups}");

            args.Add($"-x {config.CompressionRatio}");
            args.Add("--line-progress");

            // Devices
            foreach (var device in config.Devices)
            {
                if (device.IsCpu)
                {
                    args.Add($"-c {device.ThreadCount}");
                }
                else
                {
                    args.Add($"-g {device.GpuId}:{device.ThreadCount}");
                }
            }

            return string.Join(" ", args);
        }
    }
}
