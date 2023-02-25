using System;
using System.Collections.Generic;
using System.Text;

namespace Telephony
{
    public class Smartphone:IBrowse,ICall
    {
       public void Call(string number)
        {
            Console.WriteLine($"Calling... {number}");
        }
        public void Browse(string site)
        {
            Console.WriteLine($"Browsing: {site}!");
        }
    }
}
