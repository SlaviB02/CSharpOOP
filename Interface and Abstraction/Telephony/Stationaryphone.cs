using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
   public class Stationaryphone:ICall
    {
        public void Call(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
