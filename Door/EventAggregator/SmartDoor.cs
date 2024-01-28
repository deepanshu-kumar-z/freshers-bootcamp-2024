using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregator
{
    public class SmartDoor : SimpleDoor
    {
        private int timer;

        public SmartDoor(int id, int timer) : base(id)
        {
            EventAggregator.Instance.Subscribe<DoorNotifiedEvent>(TimerEnded);
            this.timer = timer;
        }

        public override void Open()
        {
            base.Open();
            EventAggregator.Instance.Publish(new DoorOpenedEvent { Duration = timer , door = this });
        }

        private void TimerEnded(DoorNotifiedEvent This)
        {
            
            EventAggregator.Instance.Publish(new AutoCloseEvent { door = This.door });
        }
    }
}
