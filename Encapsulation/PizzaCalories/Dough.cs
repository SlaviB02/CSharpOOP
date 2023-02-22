using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
   public class Dough
    {
        private string flourType;
        private string bakingTechnique;
        private double weight;
        private double calories;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        public double Calories
        {
            get { return this.CalculateCalories(); }
        }

        public string FlourType
        {
            get
            {
                return this.flourType;
            }
            set
            {
                if(value.ToLower()!="white" && value.ToLower()!="wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }
        public string BakingTechnique
        {
            get
            {
                return this.bakingTechnique;
            }
           private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower()!="homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
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
                if(value<1 || value>200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }
        private double CalculateCalories()
        {
            double totalCalories = this.weight*2;
            if(this.flourType.ToLower()=="white")
            {
                totalCalories *= 1.5;
            }
           else if(this.flourType.ToLower()=="wholegrain")
            {
                totalCalories *= 1;
            }

        if(this.bakingTechnique.ToLower()=="crispy")
            {
                totalCalories *= 0.9;
            }
        else if(this.bakingTechnique.ToLower()=="chewy")
            {
                totalCalories *= 1.1;
            }
        else if(this.bakingTechnique.ToLower()=="homemade")
            {
                totalCalories *= 1;
            }
            return totalCalories;
        }
    }
}
