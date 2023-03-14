using System;

namespace Stealer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Spy spy = new Spy();
            string result = spy.CollectGettersSetters("Stealer.Hacker");
            Console.WriteLine(result);
        }
    }
}
