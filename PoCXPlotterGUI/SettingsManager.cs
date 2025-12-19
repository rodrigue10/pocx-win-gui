using System.Collections.Generic;

namespace PoCXPlotterGUI
{
    /// <summary>
    /// Manages persistent user settings for the plotter
    /// </summary>
    public class SettingsManager
    {
        /// <summary>
        /// Loads all user settings from persistent storage
        /// </summary>
        public UserSettings LoadSettings()
        {
            return new UserSettings
            {
                AccountId = Properties.Settings.Default.ID,
                MemoryLimit = Properties.Settings.Default.mem,
                UseMemoryLimit = Properties.Settings.Default.memlimit,
                LowPriority = Properties.Settings.Default.lowprio,
                DirectIo = Properties.Settings.Default.ddio,
                Warps = Properties.Settings.Default.warps,
                Unit = Properties.Settings.Default.unit,
                MaxNonces = Properties.Settings.Default.maxnonces,
                Benchmark = Properties.Settings.Default.bench,
                ZeroCopyBuffers = Properties.Settings.Default.zcb,
                Encounters = Properties.Settings.Default.esc,
                CompressionRatio = Properties.Settings.Default.cpr,
                WorkGroups = Properties.Settings.Default.wks,
                UseCustomEncounters = Properties.Settings.Default.esc_c,
                UseCustomWorkGroups = Properties.Settings.Default.wks_c,
                NumFiles = Properties.Settings.Default.num_files,
                CpuEnabled = Properties.Settings.Default.cpu,
                CpuThreads = Properties.Settings.Default.cpulimit,
                Gpu1Enabled = Properties.Settings.Default.gpu1,
                Gpu1Threads = Properties.Settings.Default.gpu1limit,
                Gpu2Enabled = Properties.Settings.Default.gpu2,
                Gpu2Threads = Properties.Settings.Default.gpu2limit,
                Gpu3Enabled = Properties.Settings.Default.gpu3,
                Gpu3Threads = Properties.Settings.Default.gpu3limit,
                Gpu4Enabled = Properties.Settings.Default.gpu4,
                Gpu4Threads = Properties.Settings.Default.gpu4limit
            };
        }

        /// <summary>
        /// Saves account ID setting
        /// </summary>
        public void SaveAccountId(string accountId)
        {
            Properties.Settings.Default.ID = accountId;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Saves memory limit setting
        /// </summary>
        public void SaveMemoryLimit(int memoryLimitMiB)
        {
            Properties.Settings.Default.mem = memoryLimitMiB;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Saves memory limit enabled flag
        /// </summary>
        public void SaveMemoryLimitEnabled(bool enabled)
        {
            Properties.Settings.Default.memlimit = enabled;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Saves max nonces setting
        /// </summary>
        public void SaveMaxNonces(bool maxNonces)
        {
            Properties.Settings.Default.maxnonces = maxNonces;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Saves warps setting
        /// </summary>
        public void SaveWarps(decimal warps)
        {
            Properties.Settings.Default.warps = warps;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Saves unit setting
        /// </summary>
        public void SaveUnit(int unit)
        {
            Properties.Settings.Default.unit = unit;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Saves low priority setting
        /// </summary>
        public void SaveLowPriority(bool lowPriority)
        {
            Properties.Settings.Default.lowprio = lowPriority;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Saves direct I/O setting
        /// </summary>
        public void SaveDirectIo(bool directIo)
        {
            Properties.Settings.Default.ddio = directIo;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Saves benchmark setting
        /// </summary>
        public void SaveBenchmark(bool benchmark)
        {
            Properties.Settings.Default.bench = benchmark;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Saves zero-copy buffers setting
        /// </summary>
        public void SaveZeroCopyBuffers(bool zcb)
        {
            Properties.Settings.Default.zcb = zcb;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Saves encounters setting
        /// </summary>
        public void SaveEncounters(decimal encounters)
        {
            Properties.Settings.Default.esc = encounters;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Saves compression ratio setting
        /// </summary>
        public void SaveCompressionRatio(decimal cpr)
        {
            Properties.Settings.Default.cpr = cpr;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Saves work groups setting
        /// </summary>
        public void SaveWorkGroups(decimal wks)
        {
            Properties.Settings.Default.wks = wks;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Saves custom encounters enabled flag
        /// </summary>
        public void SaveCustomEncountersEnabled(bool enabled)
        {
            Properties.Settings.Default.esc_c = enabled;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Saves custom work groups enabled flag
        /// </summary>
        public void SaveCustomWorkGroupsEnabled(bool enabled)
        {
            Properties.Settings.Default.wks_c = enabled;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Saves number of files setting
        /// </summary>
        public void SaveNumFiles(decimal numFiles)
        {
            Properties.Settings.Default.num_files = numFiles;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Saves device settings
        /// </summary>
        public void SaveDeviceSettings(List<DeviceSettings> devices)
        {
            if (devices.Count > 0 && devices[0].Type == DeviceSettings.DeviceType.CPU)
            {
                Properties.Settings.Default.cpu = devices[0].Enabled;
                Properties.Settings.Default.cpulimit = devices[0].Threads;
            }

            int gpuIndex = 0;
            for (int i = 1; i < devices.Count; i++)
            {
                if (devices[i].Type == DeviceSettings.DeviceType.GPU)
                {
                    switch (gpuIndex)
                    {
                        case 0:
                            Properties.Settings.Default.gpu1 = devices[i].Enabled;
                            Properties.Settings.Default.gpu1limit = devices[i].Threads;
                            break;
                        case 1:
                            Properties.Settings.Default.gpu2 = devices[i].Enabled;
                            Properties.Settings.Default.gpu2limit = devices[i].Threads;
                            break;
                        case 2:
                            Properties.Settings.Default.gpu3 = devices[i].Enabled;
                            Properties.Settings.Default.gpu3limit = devices[i].Threads;
                            break;
                        case 3:
                            Properties.Settings.Default.gpu4 = devices[i].Enabled;
                            Properties.Settings.Default.gpu4limit = devices[i].Threads;
                            break;
                    }
                    gpuIndex++;
                }
            }

            Properties.Settings.Default.Save();
        }
    }

    /// <summary>
    /// Holds all user settings
    /// </summary>
    public class UserSettings
    {
        public string AccountId { get; set; }
        public int MemoryLimit { get; set; }
        public bool UseMemoryLimit { get; set; }
        public bool LowPriority { get; set; }
        public bool DirectIo { get; set; }
        public decimal Warps { get; set; }
        public int Unit { get; set; }
        public bool MaxNonces { get; set; }
        public bool Benchmark { get; set; }
        public bool ZeroCopyBuffers { get; set; }
        public decimal Encounters { get; set; }
        public decimal CompressionRatio { get; set; }
        public decimal WorkGroups { get; set; }
        public bool UseCustomEncounters { get; set; }
        public bool UseCustomWorkGroups { get; set; }
        public decimal NumFiles { get; set; }
        public bool CpuEnabled { get; set; }
        public int CpuThreads { get; set; }
        public bool Gpu1Enabled { get; set; }
        public int Gpu1Threads { get; set; }
        public bool Gpu2Enabled { get; set; }
        public int Gpu2Threads { get; set; }
        public bool Gpu3Enabled { get; set; }
        public int Gpu3Threads { get; set; }
        public bool Gpu4Enabled { get; set; }
        public int Gpu4Threads { get; set; }
    }

    /// <summary>
    /// Device settings for persistence
    /// </summary>
    public class DeviceSettings
    {
        public enum DeviceType
        {
            CPU,
            GPU
        }

        public DeviceType Type { get; set; }
        public bool Enabled { get; set; }
        public int Threads { get; set; }
    }
}
