using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class AutoClose
    {
        public void AutoCloseEvent(SmartDoor smartDoor)
        {
            Console.WriteLine($"Open for too long!! AutoClose activated for Door {smartDoor.id}");
            smartDoor.Close();
        }
    }
}
