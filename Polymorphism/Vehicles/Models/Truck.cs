using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
   public class Truck:Vehicles
    {
        private const double additionalConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption)
        {

        }

        protected override double AdditionalConsumption => additionalConsumption;
        public override void Refuel(double fuel)
        {
            base.Refuel(fuel * 0.95);
        }
    }
}
