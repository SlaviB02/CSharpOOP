using System;

namespace WildFarm.Core.Interfaces
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
