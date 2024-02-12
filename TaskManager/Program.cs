using System;

namespace ConsoleApp8
{
    public class Program
    {
        static void Main()
        {
            Printer printerObj = new Printer();
            Scanner scannerObj = new Scanner();
            PrintScanner printScannerObj = new PrintScanner();

            TaskManager.ExecuctePrintTask(printerObj, "Test.doc");
            TaskManager.ExecucteScanTask(scannerObj, "MyImage.png");
            TaskManager.ExecuctePrintTask(printScannerObj, "NewDoc.doc");
            TaskManager.ExecucteScanTask(printScannerObj, "YourImage.png");
        }
    }

}