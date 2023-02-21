using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person> people = new List<Person>();
            for(int i=0;i<n;i++)
            {
                string[] input = Console.ReadLine().Split();
                Person person = new Person(input[0], input[1], int.Parse(input[2]),decimal.Parse(input[3]));
                people.Add(person);
            }
            var percentage = decimal.Parse(Console.ReadLine());
            people.ForEach(p => p.IncreaseSalary(percentage));
            Team team = new Team("Softuni");
            foreach(var person in people)
            {
                team.AddPlayer(person);
            }
            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}
