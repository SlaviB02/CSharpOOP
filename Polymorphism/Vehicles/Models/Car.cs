using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
   public class Car:Vehicles
    {
        private const double additionalConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption):base(fuelQuantity,fuelConsumption)
        {

        }
       protected override double AdditionalConsumption =>additionalConsumption;
    }
}
