using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Pager : IAdditionalFeature
    {
        public void AddFeature(SmartDoor smartDoor)
        {
            Console.WriteLine($"Open for too long!! Pager activated for Door {smartDoor.id}");
        }
    }
}
