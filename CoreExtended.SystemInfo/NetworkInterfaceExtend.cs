using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;

namespace CoreExtended.SystemInfo
{
    /// <summary>
    /// 网络扩展
    /// </summary>
    public static class NetworkInterfaceExtend
    {
        /// <summary>
        /// 获取所有网卡信息
        /// </summary>
        /// <param name="networkInterface"></param>
        /// <returns></returns>
        public static IEnumerable<NetworkInfo> GetNetworkInfos(this NetworkInterface networkInterface)
        {
            List<NetworkInfo> infos = new List<NetworkInfo>();
            NetworkInterface[] networkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface network in networkInterfaces)
            {
                NetworkInfo info = new NetworkInfo
                {
                    Id = network.Id,
                    Name = network.Name,
                    Desc = network.Description,
                    Mac = network.GetPhysicalAddress().ToString(),
                    IsPhysicsNetwork = IsPhysicsNetwork(network.Id),
                    OperationalStatus = network.OperationalStatus,
                    NetworkInterfaceType = network.NetworkInterfaceType,
                    Speed = network.Speed,
                    IsWlan = network.NetworkInterfaceType.Equals(NetworkInterfaceType.Wireless80211),
                    IPs = SetIPInfo(network)
                };
                infos.Add(info);
            }
            return infos;
        }

        /// <summary>
        /// 判断网卡是不是物理网卡
        /// </summary>
        /// <param name="id"></param>
        /// <returns>目前仅判断了Window系统;</returns>
        private static bool IsPhysicsNetwork(string id)
        {
            bool isWindow = false;
#if NETFRAMEWORK
            List<PlatformID> winPlatforms = new List<PlatformID> {
                PlatformID.Win32NT,
                PlatformID.Win32Windows,
                PlatformID.Win32S,
                PlatformID.WinCE,
                PlatformID.Xbox,
            };
            isWindow = winPlatforms.Contains(Environment.OSVersion.Platform);
#elif NET5_0_OR_GREATER
            isWindow = OperatingSystem.IsWindows();
#endif
            if (isWindow)
            {
                string queryString = $"SELECT * FROM Win32_NetworkAdapter WHERE Guid ='{id}' ";
                using (ManagementObjectSearcher _searcher = new ManagementObjectSearcher(queryString))
                {
                    ManagementObjectCollection objects = _searcher.Get();
                    int count = objects.Count;
                    foreach (ManagementObject item in objects)
                    {
                        object _value = item.Properties["PhysicalAdapter"]?.Value;
                        return (bool)(_value ?? false);
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// 获取网卡的IP信息
        /// </summary>
        /// <param name="network"></param>
        /// <returns></returns>
        private static List<IPInfo> SetIPInfo(NetworkInterface network)
        {
            List<IPInfo> ips = new List<IPInfo>();
            IPInterfaceProperties properties = network.GetIPProperties();
            foreach (UnicastIPAddressInformation ipAddress in properties.UnicastAddresses)
            {
                AddressFamily addressFamily = ipAddress.Address.AddressFamily;
                IPInfo ip = new IPInfo { 
                    IsIPV4 = addressFamily == AddressFamily.InterNetwork,
                    IsIPV6 = addressFamily == AddressFamily.InterNetworkV6,
                    DefaultGateway = properties.GatewayAddresses.AsEnumerable().FirstOrDefault(s=>s.Address.AddressFamily == addressFamily)?.Address.ToString(),
                    IP = ipAddress.Address.ToString(),
                    Mask = ipAddress.IPv4Mask.ToString(),
                    DNS = properties.DnsAddresses.Where(s => s.AddressFamily == addressFamily).Select(s=>s.ToString())
                };
                ips.Add(ip);
            }
            return ips;
        }

        /// <summary>
        /// 设置网卡IP信息
        /// </summary>
        /// <param name="networkName">网站名称</param>
        /// <param name="ip">IP地址</param>
        /// <param name="gateway">默认网关</param>
        /// <param name="mask">子网掩码</param>
        public static void SetIP(string networkName, string ip, string gateway, string mask)
        { }
    }
}
