using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator
{
    public enum DoorState { Opened, Closed }

    public class SimpleDoor
    {
        public DoorState State { get; private set; }
        public int Id { get; private set; }

        public SimpleDoor(int id)
        {
            Id = id;
            State = DoorState.Closed;
        }

        public virtual void Open()
        {
            State = DoorState.Opened;
            Console.WriteLine($"Door {Id} is now open.");
        }

        public void Close()
        {
            State = DoorState.Closed;
            Console.WriteLine($"Door {Id} is now closed.");
        }
    }
}
