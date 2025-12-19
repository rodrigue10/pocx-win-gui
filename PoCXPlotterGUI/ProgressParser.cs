using System;

namespace PoCXPlotterGUI
{
    /// <summary>
    /// Event args for hash progress updates
    /// </summary>
    public class HashProgressEventArgs : EventArgs
    {
        public int Percent { get; set; }
        public double MibPerSecond { get; set; }
        public string RawProgressString { get; set; }
    }

    /// <summary>
    /// Event args for write progress updates
    /// </summary>
    public class WriteProgressEventArgs : EventArgs
    {
        public int Percent { get; set; }
        public double MibPerSecond { get; set; }
        public string EtaString { get; set; }
        public string RawProgressString { get; set; }
    }

    /// <summary>
    /// Event args for standard output
    /// </summary>
    public class OutputEventArgs : EventArgs
    {
        public string Data { get; set; }
    }

    /// <summary>
    /// Parses plotter subprocess output and raises events for progress updates
    /// </summary>
    public class ProgressParser
    {
        private const string PROGRESS_MARKER_TOTAL = "#TOTAL";
        private const string PROGRESS_MARKER_HASH_DELTA = "#HASH_DELTA";
        private const string PROGRESS_MARKER_WRITE_DELTA = "#WRITE_DELTA";
        private const int BYTES_PER_KIB = 1024;

        private DateTime _processStartTime;
        private long _totalWarps = 0;
        private long _hashCurrentWarps = 0;
        private long _writeCurrentWarps = 0;

        public event EventHandler<HashProgressEventArgs> HashProgressUpdated;
        public event EventHandler<WriteProgressEventArgs> WriteProgressUpdated;
        public event EventHandler<OutputEventArgs> StandardOutputReceived;
        public event EventHandler<OutputEventArgs> ErrorOutputReceived;

        public ProgressParser(DateTime processStartTime)
        {
            _processStartTime = processStartTime;
        }

        /// <summary>
        /// Parses a line of standard output from the plotter process
        /// </summary>
        public void ParseStandardOutput(string data)
        {
            if (string.IsNullOrEmpty(data))
                return;

            // Check for progress messages
            if (data.StartsWith(PROGRESS_MARKER_TOTAL, StringComparison.Ordinal))
            {
                ParseTotal(data);
            }
            else if (data.StartsWith(PROGRESS_MARKER_HASH_DELTA, StringComparison.Ordinal))
            {
                ParseHashDelta(data);
            }
            else if (data.StartsWith(PROGRESS_MARKER_WRITE_DELTA, StringComparison.Ordinal))
            {
                ParseWriteDelta(data);
            }
            else
            {
                // Regular output
                StandardOutputReceived?.Invoke(this, new OutputEventArgs { Data = data });
            }
        }

        /// <summary>
        /// Parses a line of error output from the plotter process
        /// </summary>
        public void ParseErrorOutput(string data)
        {
            if (string.IsNullOrEmpty(data))
                return;

            ErrorOutputReceived?.Invoke(this, new OutputEventArgs { Data = data });
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

                // Reset both counters when receiving new total
                _hashCurrentWarps = 0;
                _writeCurrentWarps = 0;
            }
            catch (Exception)
            {
                // Ignore malformed messages
            }
        }

        /// <summary>
        /// Parses #HASH_DELTA:deltaWarps
        /// </summary>
        private void ParseHashDelta(string data)
        {
            try
            {
                // Format: #HASH_DELTA:10
                var parts = data.Split(':');
                long delta = long.Parse(parts[1]);

                _hashCurrentWarps += delta; // Accumulate

                // Calculate percentage
                int percent = _totalWarps > 0
                    ? (int)((_hashCurrentWarps * 100) / _totalWarps)
                    : 0;

                // Calculate speed (MiB/s)
                var mibProcessed = _hashCurrentWarps * BYTES_PER_KIB; // 1 warp = 1 GiB = 1024 MiB
                var elapsedSeconds = (DateTime.Now - _processStartTime).TotalSeconds;
                var mibPerSecond = elapsedSeconds > 0 ? mibProcessed / elapsedSeconds : 0;

                HashProgressUpdated?.Invoke(this, new HashProgressEventArgs
                {
                    Percent = percent,
                    MibPerSecond = mibPerSecond,
                    RawProgressString = $"{_hashCurrentWarps} of {_totalWarps} warps"
                });
            }
            catch (Exception)
            {
                // Ignore malformed progress messages
            }
        }

        /// <summary>
        /// Parses #WRITE_DELTA:deltaWarps
        /// </summary>
        private void ParseWriteDelta(string data)
        {
            try
            {
                // Format: #WRITE_DELTA:10
                var parts = data.Split(':');
                long delta = long.Parse(parts[1]);

                _writeCurrentWarps += delta; // Accumulate

                // Calculate percentage
                int percent = _totalWarps > 0
                    ? (int)((_writeCurrentWarps * 100) / _totalWarps)
                    : 0;

                // Calculate speed (MiB/s)
                var mibProcessed = _writeCurrentWarps * BYTES_PER_KIB; // 1 warp = 1 GiB = 1024 MiB
                var elapsedSeconds = (DateTime.Now - _processStartTime).TotalSeconds;
                var mibPerSecond = elapsedSeconds > 0 ? mibProcessed / elapsedSeconds : 0;

                // Calculate ETA
                long remainingWarps = _totalWarps - _writeCurrentWarps;
                long remainingMib = remainingWarps * BYTES_PER_KIB;
                double remainingSeconds = mibPerSecond > 0 ? remainingMib / mibPerSecond : 0;
                TimeSpan eta = TimeSpan.FromSeconds(remainingSeconds);
                string etaString = FormatEta(eta);

                WriteProgressUpdated?.Invoke(this, new WriteProgressEventArgs
                {
                    Percent = percent,
                    MibPerSecond = mibPerSecond,
                    EtaString = etaString,
                    RawProgressString = $"{_writeCurrentWarps} of {_totalWarps} warps"
                });
            }
            catch (Exception)
            {
                // Ignore malformed progress messages
            }
        }

        /// <summary>
        /// Formats ETA timespan into human-readable string
        /// </summary>
        private string FormatEta(TimeSpan eta)
        {
            if (eta.TotalSeconds < 60)
                return $"{eta.Seconds}s";
            else if (eta.TotalHours < 1)
                return $"{eta.Minutes}m {eta.Seconds}s";
            else if (eta.TotalHours < 24)
                return $"{(int)eta.TotalHours}h {eta.Minutes}m";
            else
                return $"{eta.Days}d {eta.Hours}h";
        }
    }
}
