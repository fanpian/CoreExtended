using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoreExtended.SystemInfo
{
    /// <summary>
    /// 操作系统判断
    /// </summary>
    public static class OSPlatform
    {
        /// <summary>
        /// 判断是不是Window系统
        /// </summary>
        /// <returns></returns>
        public static bool IsWindow()
        {
#if NETFRAMEWORK
            List<PlatformID> winPlatforms = new List<PlatformID> {
                PlatformID.Win32NT,
                PlatformID.Win32Windows,
                PlatformID.Win32S,
                PlatformID.WinCE,
                PlatformID.Xbox,
            };
            return winPlatforms.Contains(Environment.OSVersion.Platform);
#elif NET5_0_OR_GREATER
            return OperatingSystem.IsWindows();
#endif
        }

        /// <summary>
        /// 是不是Linux
        /// </summary>
        /// <returns></returns>
        public static bool IsLinux()
        {
#if NET5_0_OR_GREATER
            return OperatingSystem.IsLinux();
#else
            return false;
#endif
        }
    }
}
