using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;
namespace WildFarm.Models.Animals
{
   public class Tiger:Feline
    {
        private double weightmultiplier = 1.00;
        public Tiger(string name, double weight, string livingRegion, string breed) : base(name, weight,livingRegion, breed)
        {

        }

        public override List<Type> typeOfFoods => new List<Type>() { typeof(Meat) };

        public override double WeightMultiplier => this.weightmultiplier;

        public override void MakeSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
