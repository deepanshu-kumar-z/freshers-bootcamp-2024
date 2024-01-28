using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator
{
    public class Buzzer
    {
        public void Notify(AutoCloseEvent e)
        {
            SmartDoor smartDoor = e.door;

            Console.WriteLine($"Open for too long!! Buzzer activated for Door {smartDoor.Id}");
        }
    }
}
