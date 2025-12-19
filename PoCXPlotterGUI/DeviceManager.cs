using System;
using System.Collections.Generic;
using System.Management;
using OpenCL.Net;

namespace PoCXPlotterGUI
{
    /// <summary>
    /// Holds information about a detected compute device (CPU or GPU)
    /// </summary>
    public class ComputeDevice
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int ComputeUnits { get; set; }
        public DeviceType Type { get; set; }
        public bool IsEnabled { get; set; }
        public int ThreadCount { get; set; }

        public enum DeviceType
        {
            CPU,
            GPU
        }
    }

    /// <summary>
    /// Manages detection and enumeration of CPU and GPU devices
    /// </summary>
    public class DeviceManager
    {
        private const int OPENCL_DEVICE_TYPE_GPU = 4;
        private const int MAX_GPU_COUNT = 4;

        /// <summary>
        /// Detects all available CPU and GPU devices
        /// </summary>
        /// <returns>List of detected devices</returns>
        public DeviceDetectionResult DetectDevices()
        {
            var result = new DeviceDetectionResult
            {
                Devices = new List<ComputeDevice>(),
                OpenClAvailable = true
            };

            // Detect CPU
            DetectCpu(result.Devices);

            // Detect GPUs
            try
            {
                DetectGpus(result.Devices);
            }
            catch (Exception)
            {
                // GPU detection failed - OpenCL not available or no compatible GPUs
                // Gracefully fall back to CPU-only mode
                result.OpenClAvailable = false;
            }

            return result;
        }

        /// <summary>
        /// Detects CPU using WMI
        /// </summary>
        private void DetectCpu(List<ComputeDevice> devices)
        {
            using (ManagementObjectSearcher mos = new ManagementObjectSearcher(
                "root\\CIMV2",
                "SELECT * FROM Win32_Processor"))
            using (ManagementObjectCollection processors = mos.Get())
            {
                foreach (ManagementObject mo in processors)
                {
                    using (mo)
                    {
                        devices.Add(new ComputeDevice
                        {
                            Id = "CPU",
                            Name = "CPU: " + mo["Name"],
                            ComputeUnits = Convert.ToInt32(mo["NumberOfLogicalProcessors"]),
                            Type = ComputeDevice.DeviceType.CPU,
                            IsEnabled = false,
                            ThreadCount = 0
                        });
                        break; // Only use first CPU
                    }
                }
            }
        }

        /// <summary>
        /// Detects GPUs using OpenCL
        /// </summary>
        private void DetectGpus(List<ComputeDevice> devices)
        {
            Platform[] platforms = Cl.GetPlatformIDs(out ErrorCode error);
            int gpuIndex = 0;

            for (int i = 0; i < platforms.Length; i++)
            {
                Device[] gpus = Cl.GetDeviceIDs(platforms[i], DeviceType.All, out error);

                for (int j = 0; j < Math.Min(MAX_GPU_COUNT, gpus.Length); j++)
                {
                    // Only support GPU type
                    uint devicetype = Cl.GetDeviceInfo(gpus[j], OpenCL.Net.DeviceInfo.Type, out error).CastTo<uint>();
                    if (devicetype != OPENCL_DEVICE_TYPE_GPU) continue;

                    string gpuName = Cl.GetDeviceInfo(gpus[j], OpenCL.Net.DeviceInfo.Name, out error).ToString();
                    uint computeUnits = Cl.GetDeviceInfo(gpus[j], OpenCL.Net.DeviceInfo.MaxComputeUnits, out error).CastTo<uint>();

                    devices.Add(new ComputeDevice
                    {
                        Id = $"GPU[{i}:{j}]",
                        Name = $"GPU[{i}:{j}]: {gpuName}",
                        ComputeUnits = (int)computeUnits,
                        Type = ComputeDevice.DeviceType.GPU,
                        IsEnabled = false,
                        ThreadCount = 0
                    });

                    gpuIndex++;
                    if (gpuIndex >= MAX_GPU_COUNT) return; // Max GPU limit reached
                }
            }
        }
    }

    /// <summary>
    /// Result of device detection operation
    /// </summary>
    public class DeviceDetectionResult
    {
        public List<ComputeDevice> Devices { get; set; }
        public bool OpenClAvailable { get; set; }
    }
}
