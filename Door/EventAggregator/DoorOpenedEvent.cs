using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator
{
    public class DoorOpenedEvent
    {
        public SmartDoor door { get; set; }
        public int Duration { get; set; }
    }
}
