using System;

namespace PoCX.Common
{
    /// <summary>
    /// Progress information for download operation
    /// </summary>
    public class DownloadProgressEventArgs : EventArgs
    {
        public long BytesReceived { get; set; }
        public long TotalBytes { get; set; }
        public int ProgressPercentage { get; set; }
        public string FileName { get; set; }

        /// <summary>
        /// Formats bytes to human-readable string (B, KB, MB, GB)
        /// </summary>
        public static string FormatBytes(long bytes)
        {
            string[] sizes = { "B", "KB", "MB", "GB" };
            double len = bytes;
            int order = 0;
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++;
                len = len / 1024;
            }
            return $"{len:0.##} {sizes[order]}";
        }
    }
}
