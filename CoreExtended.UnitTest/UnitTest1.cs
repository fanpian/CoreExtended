using CoreExtended.SystemInfo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Management;
using System.Management.Automation;
using System.Management.Automation.Runspaces;

namespace CoreExtended.UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //GetPackageCommand cmd = new GetPackageCommand();
            //cmd.ShouldProcess("请求确认");
            //IEnumerable temp = cmd.Invoke();

            //Runspace runSpace = RunspaceFactory.CreateRunspace();
            //runSpace.Open();
            //Pipeline pipeline = runSpace.CreatePipeline();
            //Command cmd = new Command("Get-NetAdapter");
            //// cmd.Parameters.Add("Property", "value");
            //pipeline.Commands.Add(cmd);
            //Collection<PSObject> output = pipeline.Invoke();
            //foreach (PSObject obj in output)
            //{
            //    var temp = obj;
            //}

            // Command cmd = new Command("Get-NetAdapter");
            // cmd.IsScript = false;
            PowerShell ps = PowerShell.Create();
            //ps.AddCommand("Get-NetAdapter", true);
            ps.AddCommand("Get-CimInstance");
            ps.AddParameter("ClassName", "Win32_NetworkAdapter");
            ps.AddParameter("Property", "*");
            // ps.AddParameter("", "NetAdapter");

            Collection<PSObject> output = ps.Invoke();
            foreach (PSObject obj in output)
            {
                var temp = obj;
            }
        }

        [TestMethod]
        public void TestWMI()
        {
            if (OperatingSystem.IsWindows())
            {
                // string queryString = $"SELECT * FROM CIM_NetworkPort";//Root\StandardCimv2
                string queryString = $"SELECT * FROM MSFT_NetAdapter";//Root\StandardCimv2
                using (ManagementObjectSearcher _searcher = new ManagementObjectSearcher(@"Root\StandardCimv2", queryString))
                {
                    ManagementObjectCollection objects = _searcher.Get();
                    int count = objects.Count;
                    foreach (ManagementObject item in objects)
                    {
                        //object _value = item.Properties["PhysicalAdapter"]?.Value;
                        object val1 = item.Properties["Virtual"]?.Value;
                        object val2 = item.Properties["PNPDeviceID"]?.Value;
                        object val3 = item.Properties["Name"]?.Value;
                        object val4 = item.Properties["NdisPhysicalMedium"]?.Value;
                        object val5 = item.Properties["ConnectorPresent"]?.Value;// 是否有用插槽.只有物理网卡上有.
                    }
                }
            }
            // IEnumerable<NetworkInfo> infos = NetworkInterfaceExtend.GetNetworkInfos(null);
        }
    }
}
