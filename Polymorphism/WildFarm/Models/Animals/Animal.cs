using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food.Interfaces;

namespace WildFarm.Models.Animals
{
   public abstract class Animal
    {
        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        public abstract void MakeSound();
        public abstract List<Type> typeOfFoods { get; }
        public abstract double WeightMultiplier { get; }
        public void Feed(IFood food)
        {
            if(typeOfFoods.Contains(food.GetType())==true)
            {
                this.Weight += this.WeightMultiplier * food.Quantity;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }
        public override string ToString()
        {
            return $"{this.GetType().Name} [{this.Name},";
        }
    }
}
