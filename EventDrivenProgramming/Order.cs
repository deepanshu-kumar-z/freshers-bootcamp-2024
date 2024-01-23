using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    internal class Order
    {
        private int id;
        private enum state
        {
            ACCEPTED = 0,
            VERIFIED = 1,
            CONFIRMED = 2,
            PROCESSED = 3,
            REJECTED = 4,
            COMPLETED = 5
        }
        private state state1;
        public void ChangeState(int num)
        {
            state st = (state)num;
            this.state1 = st;
            Console.WriteLine(this.state1);
        }
    }
}
