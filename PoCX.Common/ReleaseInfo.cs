using System;
using Octokit;

namespace PoCX.Common
{
    /// <summary>
    /// Information about a specific GitHub release
    /// </summary>
    public class ReleaseInfo
    {
        public string Version { get; set; }
        public string ReleaseNotes { get; set; }
        public DateTime? PublishedAt { get; set; }
        public bool IsPrerelease { get; set; }
        public Release GitHubRelease { get; set; }

        public override string ToString()
        {
            string prefix = IsPrerelease ? "! " : "";
            string date = PublishedAt.HasValue ? PublishedAt.Value.ToString("yyyy-MM-dd") : "Unknown";
            return $"{prefix}{Version} ({date})";
        }
    }
}
