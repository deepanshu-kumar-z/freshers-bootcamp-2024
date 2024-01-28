using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator
{
    public class Pager
    {
        public void Notify(AutoCloseEvent e)
        {
            SmartDoor smartDoor = e.door;
            Console.WriteLine($"Open for too long!! Pager activated for Door {smartDoor.Id}");
        }
    }
}
