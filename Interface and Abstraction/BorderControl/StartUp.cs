using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace BorderControl
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            List<IId> all = new List<IId>();
            while(true)
            {
                string[] input = Console.ReadLine().Split();
                if (input[0]=="End")
                {
                    break;
                }
                if(input.Length==2)
                {
                    IId robot = new Robot(input[0],input[1]);
                    all.Add(robot);
                }
                if(input.Length==3)
                {
                    IId citizen = new Citizen(input[0], int.Parse(input[1]), input[2]);
                    all.Add(citizen);
                }
            }
            string digits = Console.ReadLine();
            var detained = all.Where(x => x.Id.EndsWith(digits)).Select(x => x.Id).ToList();
            foreach(var citizen in detained)
            {
                Console.WriteLine(citizen);
            }
        }
    }
}
