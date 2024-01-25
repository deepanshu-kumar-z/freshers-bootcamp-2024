using System;

namespace ConsoleApp5
{
    public class SmartDoor : SimpleDoor
    {
        public event Action<SmartDoor> AutoCloseTimer;
        private readonly ITimer timer;

        public SmartDoor(int id, ITimer timer) : base(id)
        {
            this.timer = timer;
        }

        public void Open()
        {
            base.Open();
            StartDoorTimer();
        }

        private void StartDoorTimer()
        {
            timer.StartTimer(() =>
            {
                if (state == DoorState.Opened)
                    AutoCloseTimer?.Invoke(this);
            }, 5000);
        }
    }
}
