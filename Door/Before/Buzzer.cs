using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Buzzer
    {
        public void BuzzerEvent(SmartDoor smartDoor)
        {
            Console.WriteLine($"Open for too long!! Buzzer activated for Door {smartDoor.id}");
        }
    }
}
