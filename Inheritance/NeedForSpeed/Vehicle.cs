using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower,double fuel)
        {
            Fuel = fuel;
            HorsePower = horsePower;
        }

       double DefaultFuelConsumption = 1.25;
        public virtual double FuelConsumption { get { return DefaultFuelConsumption; } }
        public double Fuel { get; set; }
        public int HorsePower{get;set;}
        public 	virtual void Drive(double kilometers)
        {
            Fuel -= FuelConsumption * kilometers;
        }
    }
    public class Car:Vehicle
    {
        double DefaultFuelConsumption = 3;
        public Car(int horsePower,double fuel):base(horsePower,fuel)
        {

        }
        public override double FuelConsumption => DefaultFuelConsumption;

    }
    public class FamilyCar : Car
    {
        public FamilyCar(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }
    }
    public class SportCar:Car
    {
        double DefaultFuelConsumption = 10;
        public SportCar(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }
        public override double FuelConsumption => DefaultFuelConsumption;
    }
    public class Motorcycle:Vehicle
    {
        public Motorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }
    }
    public class RaceMotorcycle:Motorcycle
    {
        double DefaultFuelConsumption = 8;
        public RaceMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }
        public override double FuelConsumption => DefaultFuelConsumption;
    }
    public class CrossMotorcycle:Motorcycle
    {
        public CrossMotorcycle(int horsePower, double fuel) : base(horsePower, fuel)
        {

        }
    }
}
