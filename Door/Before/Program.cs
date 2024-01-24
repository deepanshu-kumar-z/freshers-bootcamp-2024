using System;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleDoor simpleDoor = new SimpleDoor(1);
            simpleDoor.Open();
            simpleDoor.Close();
            bool Buzz = false;
            bool Page = true;
            bool Aclose = true;
            SmartDoor smartDoor = new SmartDoor(2);

            Buzzer buzzer = new Buzzer();
            Pager pager = new Pager();
            AutoClose autoClose = new AutoClose();
            
            if(Buzz) smartDoor.AutoCloseTimer += smartDoor => buzzer.BuzzerEvent(smartDoor);
            if(Page) smartDoor.AutoCloseTimer += smartDoor => pager.PagerEvent(smartDoor);
            if(Aclose) smartDoor.AutoCloseTimer += smartDoor => autoClose.AutoCloseEvent(smartDoor);

            smartDoor.Open();
            Console.ReadLine();
        }
    }
}
