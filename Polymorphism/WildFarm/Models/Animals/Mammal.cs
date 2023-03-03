using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Models.Animals
{
   public abstract class Mammal:Animal
    {
        public string LivingRegion { get; private set; }
        protected Mammal(string name, double weight,string livingRegion) : base(name, weight)
        {
            this.LivingRegion = livingRegion;
        }
       
    }
}
