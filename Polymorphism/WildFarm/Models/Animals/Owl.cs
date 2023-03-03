using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;

namespace WildFarm.Models.Animals
{
    public class Owl : Bird
    {
        private double weightmultiplier = 0.25;
        public Owl(string name, double weight,double wingSize) : base(name, weight,wingSize)
        {

        }

        public override List<Type> typeOfFoods => new List<Type>() { typeof(Meat) };

        public override double WeightMultiplier => this.weightmultiplier;

        public override void MakeSound()
        {
            Console.WriteLine("Hoot Hoot");
        }
       
    }
}
