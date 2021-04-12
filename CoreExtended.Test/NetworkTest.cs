﻿using CoreExtended.SystemInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.NetworkInformation;

namespace CoreExtended.Test
{
    [TestClass]
    public class NetworkTest
    {
        [TestMethod]
        public void Get()
        {
            string name = Dns.GetHostName();
            IPAddress[] ipadrlist = Dns.GetHostAddresses(name);
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface network in nics)
            {
                IPInterfaceProperties properties = network.GetIPProperties();
                string fRegistryKey = "SYSTEM\\CurrentControlSet\\Control\\Network\\{4D36E972-E325-11CE-BFC1-08002BE10318}\\" + network.Id + "\\Connection";
                RegistryKey rk = Registry.LocalMachine.OpenSubKey(fRegistryKey, false);
                string pnpInstanceID = rk.GetValue("PnpInstanceID", "").ToString();
                if (pnpInstanceID.StartsWith("PCI"))
                {
                    //如果PnpInstanceID是以PCI开头的,
                }
                int mediaSubType = Convert.ToInt32(rk.GetValue("MediaSubType", false));
            }

        }

        [TestMethod]
        public void GetNetwork()
        {
            IEnumerable<NetworkInfo> infos = NetworkInterfaceExtend.GetNetworkInfos(null);
        }
    }
}
