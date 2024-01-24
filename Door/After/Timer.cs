using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    public class Timer : ITimer
    {
        public event Action<SmartDoor> AutoCloseTimer;
        public void StartTimer(Action callback, int duration)
        {
            Thread newThread = new Thread(() =>
            {
                Thread.Sleep(duration);
                callback?.Invoke();
            });
            newThread.Start();
        }
    }
}