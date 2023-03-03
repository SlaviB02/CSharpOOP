using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public abstract class Bird : Animal
    {
        public double WingSize { get; private set; }
        protected Bird(string name, double weight,double wingSize) : base(name, weight)
        {
            this.WingSize = wingSize;
        }
        public override string ToString()
        {
            return base.ToString() + $" {this.WingSize}, {this.Weight}, {this.FoodEaten}]";
        }
    }
}
