using System;

namespace ConsoleApp5
{
    public class SmartDoor : SimpleDoor
    {
        public event Action<SmartDoor> AutoCloseTimer;
        

        public SmartDoor(int id) : base(id) { }

        public void Open()
        {
            base.Open();
            Timer();

        }

        public void Timer()
        {
            Thread newThread = new Thread(() =>
            {
                Thread.Sleep(5000);
                if (state == DoorState.Opened)
                    AutoCloseTimer?.Invoke(this);
            });
            newThread.Start();
        }
    }
}
