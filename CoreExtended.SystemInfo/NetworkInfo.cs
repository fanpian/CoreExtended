using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace CoreExtended.SystemInfo
{

    /// <summary>
    /// 网络信息
    /// </summary>
    public class NetworkInfo
    {
        /// <summary>
        /// 网卡ID
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 网卡名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 网卡描述
        /// </summary>
        public string Desc { get; set; }

        /// <summary>
        /// 是否是物理网卡
        /// </summary>
        public bool IsPhysicsNetwork { get; set; }

        /// <summary>
        /// 判断是不是无线网卡
        /// </summary>
        /// <value>true:表示是无线网卡</value>
        public bool IsWlan { get; set; }

        /// <summary>
        /// 网卡Mac地址
        /// </summary>
        public string Mac { get; set; }

        /// <summary>
        /// 获取网络连接的当前操作状态
        /// </summary>
        public OperationalStatus OperationalStatus { get; set; }

        /// <summary>
        /// 网卡接口类型
        /// </summary>
        public NetworkInterfaceType NetworkInterfaceType { get; set; }

        /// <summary>
        /// 网卡速度
        /// </summary>
        /// <remarks>如果是-1，则说明无法获取此网卡的链接速度；例如 270_000_000 表示是 270MB 的链接速度</remarks>
        public long Speed { get; set; }

        /// <summary>
        /// IP信息
        /// </summary>
        public IEnumerable<IPInfo> IPs { get; set; }
    }

    /// <summary>
    /// IP信息,包含IP地址、子网掩码、默认网关、DNS
    /// </summary>
    public class IPInfo
    {
        /// <summary>
        /// 是否是IPV4
        /// </summary>
        public bool IsIPV4 { get; set; }

        /// <summary>
        /// 是不是IPV6
        /// </summary>
        public bool IsIPV6 { get; set; }

        /// <summary>
        /// IP地址
        /// </summary>
        public string IP { get; set; }

        /// <summary>
        /// 子网掩码
        /// </summary>
        public string Mask { get; set; }

        /// <summary>
        /// 默认网关
        /// </summary>
        public string DefaultGateway { get; set; }

        /// <summary>
        /// DNS
        /// </summary>
        public IEnumerable<string> DNS { get; set; }
    }
}
