using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;
namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private double weightmultiplier = 0.10;
        public Mouse(string name, double weight, string livingRegion) : base(name, weight, livingRegion)
        {

        }

        public override List<Type> typeOfFoods => new List<Type>() { typeof(Vegetable), typeof(Fruit) };

        public override double WeightMultiplier => this.weightmultiplier;

        public override void MakeSound()
        {
            Console.WriteLine("Squeak");
        }
        public override string ToString()
        {
            return base.ToString()+$" {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
