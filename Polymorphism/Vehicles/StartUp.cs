using System;
using System.Linq;
using System.Text;
namespace Vehicles.Models
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            string [] carInput = Console.ReadLine().Split();
             Vehicles car = new Car(double.Parse(carInput[1]), double.Parse(carInput[2]));
            string[] truckInput = Console.ReadLine().Split();
            Vehicles truck = new Truck(double.Parse(truckInput[1]), double.Parse(truckInput[2]));
            int N = int.Parse(Console.ReadLine());
            for(int i=0;i<N;i++)
            {
                string[] command = Console.ReadLine().Split();
                if(command[0]=="Drive")
                {
                    if(command[1]=="Car")
                    {
                        Console.WriteLine(car.Drive(double.Parse(command[2])));
                    }
                    if(command[1]=="Truck")
                    {
                        Console.WriteLine(truck.Drive(double.Parse(command[2])));
                    }
                }
                if(command[0]=="Refuel")
                {
                    if (command[1] == "Car")
                    {
                        car.Refuel(double.Parse(command[2]));
                    }
                    if (command[1] == "Truck")
                    {
                        truck.Refuel(double.Parse(command[2]));
                    }
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
    }
}
