using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food;
namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private double weightmultiplier = 0.35;
        public Hen(string name, double weight,double wingSize) : base(name, weight,wingSize)
        {

        }

        public override List<Type> typeOfFoods => new List<Type>() { typeof(Vegetable), typeof(Fruit), typeof(Meat), typeof(Seeds) };

        public override double WeightMultiplier => this.weightmultiplier;

        public override void MakeSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
