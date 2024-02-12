using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public static class TaskManager
    {
        public static void ExecuctePrintTask(IDevice device, string documentPath)
        {
            device.PerformAction(documentPath, "Printing");
        }

        public static void ExecucteScanTask(IDevice device, string documentPath)
        {
            device.PerformAction(documentPath, "Scanning");
        }
    }

}
