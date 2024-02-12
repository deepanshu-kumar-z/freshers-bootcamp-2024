using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    public class Printer : IDevice
    {
        public void PerformAction(string path, string action)
        {
            System.Console.WriteLine($"{action} .....{path}");
        }
    }
}
