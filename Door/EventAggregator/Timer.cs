using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator
{
    public class Timer
    {
        public void StartTimer(DoorOpenedEvent e)
        {
            SmartDoor door = e.door;
            int duration = e.Duration;
            System.Threading.Thread newThread = new System.Threading.Thread(() =>
            {
                System.Threading.Thread.Sleep(duration);
                if (door.State == DoorState.Opened)
                {
                    EventAggregator.Instance.Publish(new DoorNotifiedEvent { door = door });
                }
            });
            newThread.Start();
        }
    }
}
