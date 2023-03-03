using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;
namespace WildFarm.Models.Animals
{
   public class Dog:Mammal
    {
        private double weightmultiplier = 0.40;
        public Dog(string name, double weight,string livingRegion) : base(name, weight,livingRegion)
        {

        }

        public override List<Type> typeOfFoods => new List<Type>() { typeof(Meat) };

        public override double WeightMultiplier => this.weightmultiplier;

        public override void MakeSound()
        {
            Console.WriteLine("Woof!");
        }
        public override string ToString()
        {
            return base.ToString() + $" {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
