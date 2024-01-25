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
            
            SmartDoor smartDoor = new SmartDoor(2, new Timer());
            IAdditionalFeature buzzer = new Buzzer();
            IAdditionalFeature pager = new Pager();
            IAdditionalFeature autoClose = new AutoClose();

            
            smartDoor.AutoCloseTimer += smartDoor => buzzer.AddFeature(smartDoor);
            smartDoor.AutoCloseTimer += smartDoor => pager.AddFeature(smartDoor);
            smartDoor.AutoCloseTimer += smartDoor => autoClose.AddFeature(smartDoor);

            smartDoor.Open();
            Console.ReadLine();
        }
    }
}
