using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private List<Topping> toppings;
        private Dough dough;
        private string name;
        private double calories;

        public double Calories
        {
            get { return this.CalculateCalories(); }
        }
        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }
        public Dough Dough
        {
            get
            {
                return this.dough;
            }
            set
            {
                this.dough = value;
            }
        }
        public List<Topping> Toppings
        {
            get => this.toppings;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
           set
            {
                if(value.Length<1 || value.Length>15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        private double CalculateCalories()
        {
            double totalCalories = this.dough.Calories;
            foreach (var topping in this.toppings)
            {
                totalCalories += topping.Calories;
            }
            return totalCalories;
        }
        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }
        public override string ToString()
        {
            return $"{this.Name} - {this.Calories:F2} Calories.";
        }
    }
}
