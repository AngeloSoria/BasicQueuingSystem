using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicQueuingSystem
{
    internal class CashierClass
    {
        private int x;
        public static string getNumberInQueue = "";
        public static Queue<string> CashierQueue;

        public CashierClass()
        {
            this.x = 10000;
            CashierQueue = new Queue<string>();
        }
        public string CashierGeneratedNumber(string CashierNumber)
        {
            CashierNumber += this.x.ToString();
            this.x++;
            return CashierNumber;
        }
        public void Reset()
        {
            this.x = 10000;
            CashierQueue.Clear();
            System.Diagnostics.Debug.WriteLine("Queue has been reset.");
        }
    }
}
