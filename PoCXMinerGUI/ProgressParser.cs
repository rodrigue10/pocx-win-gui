using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace PoCXMinerGUI
{
    #region Event Args Classes

    /// <summary>
    /// Scan progress update event
    /// </summary>
    public class ScanProgressEventArgs : EventArgs
    {
        public int Percent { get; set; }
        public double WarpsPerSecond { get; set; }
        public string RawProgressString { get; set; }
        public long CurrentWarps { get; set; }
        public long TotalWarps { get; set; }
        public double EtaSeconds { get; set; } // Estimated time remaining in seconds
    }

    /// <summary>
    /// Chain state update event
    /// </summary>
    public class ChainStateEventArgs : EventArgs
    {
        public string ChainName { get; set; }
        public ulong Height { get; set; }
        public ulong BaseTarget { get; set; }
        public string GenSig { get; set; } // Last 8 chars
        public string NetworkCapacity { get; set; }
        public string CompressionRange { get; set; } // e.g., "POCX4" or "POCX2-POCX4"
        public DateTime Timestamp { get; set; }

        public ChainStateEventArgs()
        {
            Timestamp = DateTime.Now;
        }
    }

    /// <summary>
    /// Capacity information event
    /// </summary>
    public class CapacityEventArgs : EventArgs
    {
        public double TotalCapacityTiB { get; set; }
        public int TotalDrives { get; set; }
        public Dictionary<string, PlotDirInfo> PlotDirectories { get; set; }
        public DateTime Timestamp { get; set; }

        public CapacityEventArgs()
        {
            PlotDirectories = new Dictionary<string, PlotDirInfo>();
            Timestamp = DateTime.Now;
        }
    }

    public class PlotDirInfo
    {
        public string Path { get; set; }
        public int Files { get; set; }
        public double SizeTiB { get; set; }
    }

    /// <summary>
    /// Mining queue status event
    /// </summary>
    public class QueueEventArgs : EventArgs
    {
        public List<QueueItem> Queue { get; set; }
        public DateTime Timestamp { get; set; }

        public QueueEventArgs()
        {
            Queue = new List<QueueItem>();
            Timestamp = DateTime.Now;
        }
    }

    public class QueueItem
    {
        public int Position { get; set; }
        public string Chain { get; set; }
        public ulong Height { get; set; }
        public double Progress { get; set; } // 0-100%
    }

    /// <summary>
    /// Deadline submission event
    /// </summary>
    public class SubmissionEventArgs : EventArgs
    {
        public string Chain { get; set; }
        public string Account { get; set; } // Last 8 chars
        public ulong Height { get; set; }
        public string GenSig { get; set; } // Last 8 chars
        public ulong Quality { get; set; }
        public ulong Nonce { get; set; }
        public uint CompressionLevel { get; set; }
        public string PocTime { get; set; } // PoC time: seconds, "∞", or empty
        public DateTime Timestamp { get; set; }

        public SubmissionEventArgs()
        {
            Timestamp = DateTime.Now;
        }
    }

    /// <summary>
    /// Scanning status event
    /// </summary>
    public class ScanEventArgs : EventArgs
    {
        public string Chain { get; set; }
        public ulong Height { get; set; }
        public string Status { get; set; } // "scanning", "resuming", "finished", "paused"
        public double Progress { get; set; } // 0-100% (for paused)
        public double Duration { get; set; } // seconds
        public DateTime Timestamp { get; set; }

        public ScanEventArgs()
        {
            Timestamp = DateTime.Now;
        }
    }

    #endregion

    /// <summary>
    /// Parses output from pocx_miner subprocess
    /// </summary>
    public class ProgressParser
    {
        #region Progress Protocol Constants

        private const string PROGRESS_MARKER_TOTAL = "#TOTAL";
        private const string PROGRESS_MARKER_SCAN_PROGRESS = "#SCAN_PROGRESS";

        #endregion

        #region Regex Patterns

        // New block: "new block  : [chain:height], gensig=...sig8, base_target=X, network_capacity=Y, POCXZ"
        private static readonly Regex NewBlockPattern = new Regex(
            @"new block\s+:\s+\[(?<chain>[^\:]+):(?<height>\d+)\],\s+gensig=\.\.\.(?<gensig>\w+),\s+base_target=(?<basetarget>\d+),\s+network_capacity=(?<capacity>[^,]+),\s+(?<pocx>POCX\d+(?:-POCX\d+)?)",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        // Scanning: "scanning   : [chain:height], gensig=sig, base_target=X, scoop=YYYY"
        // Resuming: "resuming   : [chain:height], gensig=sig, base_target=X, scoop=YYYY"
        private static readonly Regex ScanStartPattern = new Regex(
            @"(?<action>scanning|resuming)\s+:\s+\[(?<chain>[^\:]+):(?<height>\d+)\],\s+gensig=(?<gensig>\w+),\s+base_target=(?<basetarget>\d+),\s+scoop=(?<scoop>\d+)",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        // Finished: "finished   : [chain:height]: done after 1.23s."
        private static readonly Regex FinishedPattern = new Regex(
            @"finished\s+:\s+\[(?<chain>[^\:]+):(?<height>\d+)\]:\s+done after (?<seconds>[\d\.]+)s\.",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        // Paused: "paused     : [chain:height] after 1.23s at 45.67%."
        private static readonly Regex PausedPattern = new Regex(
            @"paused\s+:\s+\[(?<chain>[^\:]+):(?<height>\d+)\]\s+after (?<seconds>[\d\.]+)s at (?<percent>[\d\.]+)%\.",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        // Accepted: "accepted: height=H, gensig=...SIG8, account=...ACC8, seed=...SEED8, nonce=N, X=X, quality=Q"
        // Accepted with time: "accepted: height=H, gensig=...SIG8, account=...ACC8, seed=...SEED8, nonce=N, X=X, quality=Q, time=T"
        private static readonly Regex AcceptedPattern = new Regex(
            @"accepted:\s+height=(?<height>\d+),\s+gensig=\.\.\.(?<gensig>\w+),\s+account=\.\.\.(?<account>\w+),\s+seed=\.\.\.(?<seed>\w+),\s+nonce=(?<nonce>\d+),\s+X=(?<compression>\d+),\s+quality=(?<quality>\d+)(?:,\s+time=(?<time>[^\s]+))?",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        // Queue waiting: "queue      : [] waiting for new block..."
        private static readonly Regex QueueWaitingPattern = new Regex(
            @"queue\s+:\s+\[\]\s+waiting",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        // Queue with items: "queue      : [chain1:height1]:25.00%>[chain2:height2]:50.00%>"
        private static readonly Regex QueuePattern = new Regex(
            @"queue\s+:\s+(?<queuedata>.+)",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        // Individual queue item: "[chain:height]:percent%>"
        private static readonly Regex QueueItemPattern = new Regex(
            @"\[(?<chain>[^\:]+):(?<height>\d+)\]:(?<percent>[\d\.]+)%",
            RegexOptions.Compiled);

        // Plot directory loaded: "path=/plots, files=10, size=1.2345 TiB"
        private static readonly Regex PlotDirPattern = new Regex(
            @"path=(?<path>[^,]+),\s+files=(?<files>\d+),\s+size=(?<size>[\d\.]+)\s+TiB",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        // Total capacity: "..done. total drives=5, total capacity=12.3456 TiB"
        private static readonly Regex TotalCapacityPattern = new Regex(
            @"\.\.done\.\s+total drives=(?<drives>\d+),\s+total capacity=(?<capacity>[\d\.]+)\s+TiB",
            RegexOptions.Compiled | RegexOptions.IgnoreCase);

        #endregion

        #region Events

        public event EventHandler<ScanProgressEventArgs> ScanProgressUpdated;
        public event EventHandler<ChainStateEventArgs> ChainStateChanged;
        public event EventHandler<CapacityEventArgs> CapacityUpdated;
        public event EventHandler<QueueEventArgs> QueueUpdated;
        public event EventHandler<SubmissionEventArgs> DeadlineSubmitted;
        public event EventHandler<ScanEventArgs> ScanStatusChanged;

        #endregion

        #region State Tracking

        private DateTime _processStartTime;
        private long _totalWarps = 0;
        private long _scanCurrentWarps = 0;
        private Dictionary<string, ChainStateEventArgs> _chainStates;
        private Dictionary<string, PlotDirInfo> _plotDirs;
        private string _currentScanningChain;

        #endregion

        public ProgressParser()
        {
            _processStartTime = DateTime.Now;
            _chainStates = new Dictionary<string, ChainStateEventArgs>();
            _plotDirs = new Dictionary<string, PlotDirInfo>();
            _currentScanningChain = "";
        }

        /// <summary>
        /// Parses a single line of output from the miner
        /// Returns true if the line should be displayed in the log output
        /// </summary>
        public bool ParseLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return false;

            try
            {
                // Check for progress protocol messages first (high priority)
                // These should NOT be displayed in the log
                if (line.StartsWith(PROGRESS_MARKER_TOTAL, StringComparison.Ordinal))
                {
                    ParseTotal(line);
                    return false; // Don't display progress markers
                }

                if (line.StartsWith(PROGRESS_MARKER_SCAN_PROGRESS, StringComparison.Ordinal))
                {
                    ParseScanProgress(line);
                    return false; // Don't display progress markers
                }

                // Try all patterns (order matters for performance)

                // Check for new block (most common during mining)
                var match = NewBlockPattern.Match(line);
                if (match.Success)
                {
                    ParseNewBlock(match);
                    return true; // Display in log
                }

                // Check for queue status
                if (QueueWaitingPattern.IsMatch(line))
                {
                    QueueUpdated?.Invoke(this, new QueueEventArgs()); // Empty queue
                    return true; // Display in log
                }

                match = QueuePattern.Match(line);
                if (match.Success)
                {
                    ParseQueue(match);
                    return true; // Display in log
                }

                // Check for scan start/resume
                match = ScanStartPattern.Match(line);
                if (match.Success)
                {
                    ParseScanStart(match);
                    return true; // Display in log
                }

                // Check for finished
                match = FinishedPattern.Match(line);
                if (match.Success)
                {
                    ParseFinished(match);
                    return true; // Display in log
                }

                // Check for paused
                match = PausedPattern.Match(line);
                if (match.Success)
                {
                    ParsePaused(match);
                    return true; // Display in log
                }

                // Check for accepted deadline
                match = AcceptedPattern.Match(line);
                if (match.Success)
                {
                    ParseAccepted(match);
                    return true; // Display in log
                }

                // Check for plot directory loaded
                match = PlotDirPattern.Match(line);
                if (match.Success)
                {
                    ParsePlotDir(match);
                    return true; // Display in log
                }

                // Check for total capacity
                match = TotalCapacityPattern.Match(line);
                if (match.Success)
                {
                    ParseTotalCapacity(match);
                    return true; // Display in log
                }

                // Unknown line format - display in log
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error parsing line: {ex.Message}");
                return true; // Display in log even if parsing fails
            }
        }

        #region Parse Methods

        private void ParseNewBlock(Match match)
        {
            string chain = match.Groups["chain"].Value;
            ulong height = ulong.Parse(match.Groups["height"].Value);
            string gensig = match.Groups["gensig"].Value;
            ulong baseTarget = ulong.Parse(match.Groups["basetarget"].Value);
            string capacity = match.Groups["capacity"].Value;
            string pocx = match.Groups["pocx"].Value; // e.g., "POCX4" or "POCX2-POCX4"

            var eventArgs = new ChainStateEventArgs
            {
                ChainName = chain,
                Height = height,
                BaseTarget = baseTarget,
                GenSig = gensig,
                NetworkCapacity = capacity,
                CompressionRange = pocx
            };

            // Update chain state
            _chainStates[chain] = eventArgs;

            ChainStateChanged?.Invoke(this, eventArgs);
        }

        private void ParseScanStart(Match match)
        {
            string action = match.Groups["action"].Value;
            string chain = match.Groups["chain"].Value;
            ulong height = ulong.Parse(match.Groups["height"].Value);

            _currentScanningChain = chain;

            // Reset scan start time for ETA calculation
            _processStartTime = DateTime.Now;

            ScanStatusChanged?.Invoke(this, new ScanEventArgs
            {
                Chain = chain,
                Height = height,
                Status = action.ToLower(), // "scanning" or "resuming"
                Progress = 0
            });
        }

        private void ParseFinished(Match match)
        {
            string chain = match.Groups["chain"].Value;
            ulong height = ulong.Parse(match.Groups["height"].Value);
            double seconds = double.Parse(match.Groups["seconds"].Value, CultureInfo.InvariantCulture);

            ScanStatusChanged?.Invoke(this, new ScanEventArgs
            {
                Chain = chain,
                Height = height,
                Status = "finished",
                Duration = seconds,
                Progress = 100
            });
        }

        private void ParsePaused(Match match)
        {
            string chain = match.Groups["chain"].Value;
            ulong height = ulong.Parse(match.Groups["height"].Value);
            double seconds = double.Parse(match.Groups["seconds"].Value, CultureInfo.InvariantCulture);
            double percent = double.Parse(match.Groups["percent"].Value, CultureInfo.InvariantCulture);

            ScanStatusChanged?.Invoke(this, new ScanEventArgs
            {
                Chain = chain,
                Height = height,
                Status = "paused",
                Duration = seconds,
                Progress = percent
            });
        }

        private void ParseAccepted(Match match)
        {
            ulong height = ulong.Parse(match.Groups["height"].Value);
            string gensig = match.Groups["gensig"].Value;
            string account = match.Groups["account"].Value;
            ulong nonce = ulong.Parse(match.Groups["nonce"].Value);
            uint compression = uint.Parse(match.Groups["compression"].Value);
            ulong quality = ulong.Parse(match.Groups["quality"].Value);
            string time = match.Groups["time"].Success ? match.Groups["time"].Value : "";

            // Find which chain this submission belongs to
            string chain = _currentScanningChain;

            // Try to match by height and gensig
            foreach (var kvp in _chainStates)
            {
                if (kvp.Value.Height == height && kvp.Value.GenSig == gensig)
                {
                    chain = kvp.Key;
                    break;
                }
            }

            DeadlineSubmitted?.Invoke(this, new SubmissionEventArgs
            {
                Chain = chain,
                Account = account,
                Height = height,
                GenSig = gensig,
                Quality = quality,
                Nonce = nonce,
                CompressionLevel = compression,
                PocTime = time
            });
        }

        private void ParseQueue(Match match)
        {
            string queueData = match.Groups["queuedata"].Value;

            if (queueData.Contains("waiting"))
            {
                QueueUpdated?.Invoke(this, new QueueEventArgs());
                return;
            }

            var items = new List<QueueItem>();
            var itemMatches = QueueItemPattern.Matches(queueData);

            int position = 1;
            foreach (Match itemMatch in itemMatches)
            {
                string chain = itemMatch.Groups["chain"].Value;
                ulong height = ulong.Parse(itemMatch.Groups["height"].Value);
                double percent = double.Parse(itemMatch.Groups["percent"].Value, CultureInfo.InvariantCulture);

                items.Add(new QueueItem
                {
                    Position = position++,
                    Chain = chain,
                    Height = height,
                    Progress = percent
                });
            }

            QueueUpdated?.Invoke(this, new QueueEventArgs { Queue = items });
        }

        private void ParsePlotDir(Match match)
        {
            string path = match.Groups["path"].Value;
            int files = int.Parse(match.Groups["files"].Value);
            double size = double.Parse(match.Groups["size"].Value, CultureInfo.InvariantCulture);

            _plotDirs[path] = new PlotDirInfo
            {
                Path = path,
                Files = files,
                SizeTiB = size
            };
        }

        private void ParseTotalCapacity(Match match)
        {
            int drives = int.Parse(match.Groups["drives"].Value);
            double capacity = double.Parse(match.Groups["capacity"].Value, CultureInfo.InvariantCulture);

            CapacityUpdated?.Invoke(this, new CapacityEventArgs
            {
                TotalCapacityTiB = capacity,
                TotalDrives = drives,
                PlotDirectories = new Dictionary<string, PlotDirInfo>(_plotDirs)
            });
        }

        /// <summary>
        /// Parses #TOTAL:totalWarps
        /// </summary>
        private void ParseTotal(string data)
        {
            try
            {
                // Format: #TOTAL:8000
                var parts = data.Split(':');
                _totalWarps = long.Parse(parts[1]);

                // Reset counter when receiving new total
                _scanCurrentWarps = 0;
            }
            catch (Exception)
            {
                // Ignore malformed messages
            }
        }

        /// <summary>
        /// Parses #SCAN_PROGRESS:deltaWarps
        /// </summary>
        private void ParseScanProgress(string data)
        {
            try
            {
                // Format: #SCAN_PROGRESS:10
                var parts = data.Split(':');
                long delta = long.Parse(parts[1]);

                _scanCurrentWarps += delta; // Accumulate

                // Calculate percentage
                int percent = _totalWarps > 0
                    ? (int)((_scanCurrentWarps * 100) / _totalWarps)
                    : 0;

                // Ensure percent doesn't exceed 100
                percent = Math.Min(percent, 100);

                // Calculate speed (warps/s)
                var elapsedSeconds = (DateTime.Now - _processStartTime).TotalSeconds;
                var warpsPerSecond = elapsedSeconds > 0 ? _scanCurrentWarps / elapsedSeconds : 0;

                // Calculate ETA (seconds remaining)
                long warpsRemaining = _totalWarps - _scanCurrentWarps;
                double etaSeconds = warpsPerSecond > 0 ? warpsRemaining / warpsPerSecond : 0;

                ScanProgressUpdated?.Invoke(this, new ScanProgressEventArgs
                {
                    Percent = percent,
                    WarpsPerSecond = warpsPerSecond,
                    RawProgressString = $"{_scanCurrentWarps} of {_totalWarps} warps",
                    CurrentWarps = _scanCurrentWarps,
                    TotalWarps = _totalWarps,
                    EtaSeconds = etaSeconds
                });
            }
            catch (Exception)
            {
                // Ignore malformed progress messages
            }
        }

        #endregion

        /// <summary>
        /// Resets the parser state
        /// </summary>
        public void Reset()
        {
            _processStartTime = DateTime.Now;
            _totalWarps = 0;
            _scanCurrentWarps = 0;
            _chainStates.Clear();
            _plotDirs.Clear();
            _currentScanningChain = "";
        }
    }
}
