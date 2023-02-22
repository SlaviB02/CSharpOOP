using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private string toppingType;
        private double calories;
        private double weight;
        public double Calories
        {
            get { return this.CalculateCalories(); }
        }
        public Topping(string type, double weight)
        {
            this.ToppingType = type;
            this.Weight = weight;
        }
        public string ToppingType
        {
            get { return this.toppingType; }
            private set
            {
                if(value.ToLower()!="meat" && value.ToLower()!="veggies" && value.ToLower()!="cheese" && value.ToLower()!="sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.toppingType = value;
            }
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }
        private double CalculateCalories()
        {
            double totalCalories = this.weight * 2;
            if(this.toppingType.ToLower()=="meat")
            {
                totalCalories *= 1.2;
            }
            else if(this.toppingType.ToLower()=="veggies")
            {
                totalCalories *= 0.8;
            }
            else if(this.toppingType.ToLower()=="cheese")
            {
                totalCalories *= 1.1;
            }
            else if(this.toppingType.ToLower()=="sauce")
            {
                totalCalories *= 0.9;
            }
            return totalCalories;
        }
            

    }
}
