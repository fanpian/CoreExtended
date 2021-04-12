using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;

namespace CoreExtended.SystemInfo
{
    /// <summary>
    /// 计算机信息类
    /// </summary>
    public static class ComputerInfoExtend
    {
        /// <summary>
        /// 定义内存信息结构
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        private struct MemoryInfo
        {
            /// <summary>
            /// 不清楚
            /// </summary>
            public uint dwLength;

            /// <summary>
            /// 正在使用的内存总量
            /// </summary>
            public uint dwMemoryLoad;

            /// <summary>
            /// 物理内存总量
            /// </summary>
            public uint dwTotalPhys;

            /// <summary>
            /// 未使用物理内存量
            /// </summary>
            public uint dwAvailPhys;

            /// <summary>
            /// 交换文件总大小
            /// </summary>
            public uint dwTotalPageFile;

            /// <summary>
            /// 未使用的交换文件总大小
            /// </summary>
            public uint dwAvailPageFile;

            /// <summary>
            /// 虚拟内存总大小
            /// </summary>
            public uint dwTotalVirtual;

            /// <summary>
            /// 未使用虚拟内存大小
            /// </summary>
            public uint dwAvailVirtual;
        }

        [DllImport("kernel32")]
        private static extern void GlobalMemoryStatus(ref MemoryInfo meminfo);

        private static readonly MemoryInfo _memory = new MemoryInfo();

        /// <summary>
        /// 操作系统运行的毫秒数
        /// </summary>
        public static readonly int SystemRunTime = Environment.TickCount;

        /// <summary>
        /// 当前进程已经运行毫秒数
        /// </summary>
        /// <returns></returns>
        public static long ProcessRunTime()
        {
            DateTime startTime = Process.GetCurrentProcess().StartTime;
            return (DateTime.Now.Ticks - startTime.Ticks) / 10000;
        }

        /// <summary>
        /// 已使用内存(字节)
        /// </summary>
        public static ulong MemoryToUsed { get { return _memory.dwMemoryLoad; } }

        /// <summary>
        /// 物理内存总量(字节)
        /// </summary>
        public static ulong MemoryToTotalPhysical { get { return _memory.dwTotalPhys; } }

        /// <summary>
        /// 未使用物理内存总量(字节)
        /// </summary>
        public static ulong MemoryToAvailPhysical { get { return _memory.dwAvailPhys; } }

        /// <summary>
        /// 交换文件总大小(字节)
        /// </summary>
        public static ulong MemoryToTotalPageFile { get { return _memory.dwTotalPageFile; } }

        /// <summary>
        /// 未使用的交换文件大小(字节)
        /// </summary>
        public static ulong MemoryToAvailPageFile { get { return _memory.dwAvailPageFile; } }

        /// <summary>
        /// 虚拟内存总量(字节)
        /// </summary>
        public static ulong MemoryToTotalVirtual { get { return _memory.dwTotalVirtual; } }

        /// <summary>
        /// 未使用的虚拟内存总量(字节)
        /// </summary>
        public static ulong MemoryToAvailVirtual { get { return _memory.dwAvailVirtual; } }

        /// <summary>
        /// 操作系统信息
        /// </summary>
        public static readonly OperatingSystem OS = Environment.OSVersion;

        /// <summary>
        /// Operating system kernel version<br />
        /// 操作系统内核版本
        /// <para>
        /// ex:<br />
        /// Microsoft Windows NT 6.2.9200.0<br />
        /// Unix 4.4.0.19041
        /// </para>
        /// </summary>
        public static string OSVersion => Environment.OSVersion.ToString();

        /// <summary>
        /// Gets an <see cref="PlatformID"/> identifier<br />
        /// 获取操作系统的类型
        /// <para>
        /// ex:<br />
        /// Win32S、Win32Windows、Win32NT、WinCE、Unix、Xbox、MacOSX
        /// </para>
        /// </summary>
        public static string OSPlatformID => Environment.OSVersion.Platform.ToString();


        /// <summary>
        /// .NET Fx/Core version
        /// <para>
        /// ex:<br />
        /// 3.1.9
        /// </para>
        /// </summary>
        public static string FrameworkVersion => Environment.Version.ToString();

        /// <summary>
        /// 计算机名称
        /// </summary>
        public static string MachineName => Environment.MachineName;

        /// <summary>
        /// Returns an array of string containing the names of the logical drives on the current computer<br />
        /// 系统的磁盘和分区列表
        /// <para>
        /// ex:<br />
        /// Windows: D:\, E:\, F:\, G:\, H:\, J:\, X:\<br />
        /// Linux:   /, /dev, /sys, /proc, /dev/pts, /run, /run/lock, /run/shm ...
        /// </para>
        /// </summary>
        public static string[] GetLogicalDrives => Environment.GetLogicalDrives();

        /// <summary>
        /// Gets the fully qualified path of the system directory.<b>Linux has no system directory</b><br />
        /// 系统根目录完全路径。<b>Linux 没有系统根目录</b>
        /// <para>
        /// ex:<br />
        /// Windows: X:\WINDOWS\system32<br></br>
        /// Linux  : null
        /// </para>
        /// </summary>
        public static string SystemDirectory => Environment.SystemDirectory;

#if NET5_0_OR_GREATER

        /// <summary>
        /// 操作系统架构
        /// x86,x64
        /// </summary>
        public static readonly string OSArchitecture = RuntimeInformation.OSArchitecture.ToString();

        /// <summary>
        /// 操作系统描述
        /// </summary>
        public static readonly string OSDescription = RuntimeInformation.OSDescription;

        /// <summary>
        /// 本进程的架构，可点击 <see cref="Architecture" /> 获取详细的信息
        /// <para>
        /// ex:<br />
        /// X86<br />
        /// X64<br />
        /// Arm<br />
        /// Arm64
        /// </para>
        /// </summary>
        public static string ProcessArchitecture => RuntimeInformation.ProcessArchitecture.ToString();


        /// <summary>
        /// .NET Fx/Core Runtime version
        /// <para>ex: .NET Core 3.1.9</para>
        /// </summary>
        public static string FrameworkDescription => RuntimeInformation.FrameworkDescription;
#endif


    }
}
