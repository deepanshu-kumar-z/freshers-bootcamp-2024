using System;

namespace ConsoleApp5
{
    public enum DoorState { Opened, Closed }
    public class SimpleDoor
    {
        public DoorState state { get; private set; }
        public int id {  get; private set; }

        public SimpleDoor(int id)
        {
            this.id = id;
            this.state = DoorState.Closed;

        }
        public virtual void Open()
        {
            this.state = DoorState.Opened;
            Console.WriteLine("Door is now open.");
        }

        public void Close()
        {
            this.state = DoorState.Closed;
            Console.WriteLine("Door is now closed.");
        }
    }
}
