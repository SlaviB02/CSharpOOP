using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
   public abstract class Vehicles
    {
       
        public Vehicles(double fuelQuantity, double fuelConsumption)
        {
            FuelQuantity = fuelQuantity;
            FuelConsumption = fuelConsumption;
        }

        protected abstract double AdditionalConsumption { get; }
        
        private double FuelQuantity { get; set; }
        private double FuelConsumption { get; set; }
        public string Drive(double distance)
        {
            double fuel = distance*(FuelConsumption + AdditionalConsumption);
             if(fuel<=FuelQuantity)
            {
                FuelQuantity -= fuel;
                return $"{this.GetType().Name} travelled {distance} km";
            }
            else
            {
                return $"{this.GetType().Name} needs refueling";
            }
        }
        public virtual void Refuel(double fuel)
        {
            this.FuelQuantity += fuel;
        }
        public override string ToString()
        {
           return $"{this.GetType().Name}: {FuelQuantity:F2}";
        }
    }
}
