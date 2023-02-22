using System;
using System.Linq;
namespace PizzaCalories
{
    class StartUp
    {
        static void Main(string[] args)
        {
            try
            {
                var tokens = Console.ReadLine().Split();
                Pizza pizza = new Pizza(tokens[1]);
                tokens = Console.ReadLine().Split();
                pizza.Dough = new Dough(tokens[1], tokens[2], double.Parse(tokens[3]));

                string command;
                while ((command = Console.ReadLine()) != "END")
                {
                    tokens = command.Split();
                    Topping topping = new Topping(tokens[1], double.Parse(tokens[2]));
                    pizza.AddTopping(topping);
                }
                Console.WriteLine(pizza);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
       
            
        
    }
}
