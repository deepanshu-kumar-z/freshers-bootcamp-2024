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
            SmartDoor smartDoor = new SmartDoor(2, new Timer());
            IAdditionalFeature buzzer = new Buzzer();
            IAdditionalFeature pager = new Pager();
            IAdditionalFeature autoClose = new AutoClose();

            
            if(Buzz) smartDoor.AutoCloseTimer += smartDoor => buzzer.AddFeature(smartDoor);
            if(Page) smartDoor.AutoCloseTimer += smartDoor => pager.AddFeature(smartDoor);
            if(Aclose) smartDoor.AutoCloseTimer += smartDoor => autoClose.AddFeature(smartDoor);

            smartDoor.Open();
            Console.ReadLine();
        }
    }
}
