using System;
#if NET5_0_OR_GREATER
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management.Automation;
using System.Diagnostics;

namespace CoreExtended.SystemInfo
{
    [Cmdlet(VerbsCommon.Get,"Service",SupportsShouldProcess = true)]
    public class GetPackageCommand : Cmdlet
    {
        protected override void BeginProcessing()
        {
            base.BeginProcessing();
        }

        protected override void EndProcessing()
        {
            base.EndProcessing();
        }

        public override string GetResourceString(string baseName, string resourceId)
        {
            return base.GetResourceString(baseName, resourceId);
        }

        protected override void StopProcessing()
        {
            base.StopProcessing();
        }

        protected override void ProcessRecord()
        {
            //Process[] processes = Process.GetProcesses();
            //WriteObject(processes);
            base.ProcessRecord();
        }

        
    }
}
#endif