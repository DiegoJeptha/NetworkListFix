using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace NetworkListFix
{
      class Program
      {
            public static string ServiceName = "netprofm";
            private static void Main(string[] args)
            {
                  ServiceController sc = new ServiceController(ServiceName);
                  if (!sc.Status.Equals(ServiceControllerStatus.Running)) {
                        Enable();
                        sc.Start();
                  }
                  Console.WriteLine("Fixed Master");
            }

            private static void Enable() {
                  using (var m = new ManagementObject(string.Format("Win32_Service.Name=\"{0}\"", ServiceName)))
                  {
                        m.InvokeMethod("ChangeStartMode", new object[] { "Automatic" });
                  }
            }
      }
}
