using System;
using System.Collections.Generic;

namespace PoCX.Common
{
    /// <summary>
    /// Base class for update check results
    /// </summary>
    public class UpdateCheckResultBase
    {
        public bool UpdateAvailable { get; set; }
        public string LatestVersion { get; set; }
        public string CurrentVersion { get; set; }
        public string ReleaseNotes { get; set; }
        public DateTime? PublishedAt { get; set; }
        public List<ReleaseInfo> AvailableReleases { get; set; }

        public UpdateCheckResultBase()
        {
            AvailableReleases = new List<ReleaseInfo>();
        }
    }
}
