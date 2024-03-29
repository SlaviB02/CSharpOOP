﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
    public abstract class Feline : Mammal
    {
        public string Breed { get; private set; }
        protected Feline(string name, double weight, string livingRegion,string breed) : base(name, weight,  livingRegion)
        {
            this.Breed = breed;
        }
        public override string ToString()
        {
            return base.ToString()+$" {this.Breed}, {this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
