using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using WildFarm.Models.Animals;
using WildFarm.Models.Food;

namespace WildFarm.Core.Interfaces
{
    public class Engine : IEngine
    {
        public void Run()
        {
            List<Animal> animals = new List<Animal>();
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] animalInput = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                string[] foodInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                Animal animal = null;
                if (animalInput[0] == "Owl")
                {
                    animal = new Owl(animalInput[1], double.Parse(animalInput[2]), double.Parse(animalInput[3]));

                }
                else if (animalInput[0] == "Hen")
                {
                    animal = new Hen(animalInput[1], double.Parse(animalInput[2]), double.Parse(animalInput[3]));

                }
                else if (animalInput[0] == "Mouse")
                {
                    animal = new Mouse(animalInput[1], double.Parse(animalInput[2]), animalInput[3]);

                }
                else if (animalInput[0] == "Cat")
                {
                    animal = new Cat(animalInput[1], double.Parse(animalInput[2]), animalInput[3], animalInput[4]);

                }
                else if (animalInput[0] == "Dog")
                {
                    animal = new Dog(animalInput[1], double.Parse(animalInput[2]), animalInput[3]);

                }
                else if (animalInput[0] == "Tiger")
                {
                    animal = new Tiger(animalInput[1], double.Parse(animalInput[2]), animalInput[3], animalInput[4]);

                }
                animals.Add(animal);
                animal.MakeSound();

                string foodType = foodInput[0];
                int quantity = int.Parse(foodInput[1]);
                Food food = null;
                if (foodType == "Fruit")
                {
                    food = new Fruit(quantity);
                }
                else if (foodType == "Meat")
                {
                    food = new Meat(quantity);
                }
                else if (foodType == "Seeds")
                {
                    food = new Seeds(quantity);
                }
                else if (foodType == "Vegetable")
                {
                    food = new Vegetable(quantity);
                }
                animal.Feed(food);

            }
            foreach (var a in animals)
            {
                Console.WriteLine(a);
            }
        }
    }
}
