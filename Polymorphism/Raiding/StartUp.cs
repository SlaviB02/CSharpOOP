using System;
using System.Collections.Generic;
namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            List<BaseHero> group = new List<BaseHero>();
            int counter = 0;
            while(N!=counter)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();
                if(type=="Druid")
                {
                    BaseHero druid = new Druid(name);
                    group.Add(druid);
                    counter++;
                }
                else if(type=="Paladin")
                {
                    BaseHero paladin = new Paladin(name);
                    group.Add(paladin);
                    counter++;
                }
                else if(type=="Rogue")
                {
                    BaseHero rogue = new Rogue(name);
                    group.Add(rogue);
                    counter++;
                }
                else if(type=="Warrior")
                {
                    BaseHero warrior = new Warrior(name);
                    group.Add(warrior);
                    counter++;
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }
            }
            int bossPower = int.Parse(Console.ReadLine());
            int groupPower = 0;
            foreach(var hero in group)
            {
                groupPower += hero.Power;
                Console.WriteLine(hero.CastAbility());
                if(groupPower>=bossPower)
                {
                    Console.WriteLine("Victory!");
                    return;
                }
            }
            Console.WriteLine("Defeat...");


        }
    }
}
