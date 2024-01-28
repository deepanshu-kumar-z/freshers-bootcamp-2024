using System;

namespace EventAggregator
{

    class Program
    {
        static void Main()
        {
            SimpleDoor doorsimple = new SimpleDoor(2);
            doorsimple.Open();
            doorsimple.Close();

            Timer timer = new Timer();
            Pager pager = new Pager();
            AutoClose autoClose = new AutoClose();
            Buzzer buzzer = new Buzzer();

            EventAggregator.Instance.Subscribe<DoorOpenedEvent>(timer.StartTimer);
            
            EventAggregator.Instance.Subscribe<AutoCloseEvent>(buzzer.Notify);
            EventAggregator.Instance.Subscribe<AutoCloseEvent>(pager.Notify);
            EventAggregator.Instance.Subscribe<AutoCloseEvent>(autoClose.Notify);

            SmartDoor smartDoor = new SmartDoor(1, 3000);
            

            smartDoor.Open();
            Console.ReadLine();
        }
    }
}
