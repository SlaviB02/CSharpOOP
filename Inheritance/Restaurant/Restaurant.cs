using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public virtual string Name { get; set; }
        public virtual decimal Price { get; set; }

    }
    public class Beverage:Product
    {
        public Beverage(string name,decimal price,double milliliters):base(name,price)
        {
            this.Milliliters = milliliters;
        }
        public virtual double  Milliliters { get; set; }
    }
    public class HotBeverage:Beverage
    {
        public HotBeverage(string name, decimal price, double milliliters) : base(name, price,milliliters)
        {

        }
    }
    public class Coffee : HotBeverage
    {
        public Coffee(string name,double caffeine) : base(name,0,0)
        {
            this.Caffeine = caffeine;
        }
       const double coffeeMilliliters = 50;
       const decimal coffeePrice = 3.50M;
        public override double Milliliters { get => coffeeMilliliters; }
        public override decimal Price { get => coffeePrice; }
        public double Caffeine{get;set;}
    }
    public class Tea:HotBeverage
    {
        public Tea(string name, decimal price, double milliliters) : base(name, price, milliliters)
        {

        }
    }
    public class ColdBeverage : Beverage
    {
        public ColdBeverage(string name, decimal price, double milliliters) : base(name, price, milliliters)
        {

        }
    }

    public class Food : Product
    {
        public Food(string name, decimal price, double grams) : base(name, price)
        {
            this.Grams = grams;
        }
        public virtual double Grams { get; set; }
    }
    public class Dessert:Food
    {
        public Dessert(string name,decimal price,double grams,double calories):base(name,price,grams)
        {
            this.Calories = calories;
        }
        public virtual double Calories { get; set; }
    }
    public class MainDish:Food
    {
        public MainDish(string name, decimal price, double grams) : base(name, price,grams)
        {
            
        }
    }
    public class Starter : Food
    {
        public Starter(string name, decimal price, double grams) : base(name, price, grams)
        {

        }
    }
    public class Soup:Starter
    {
        public Soup(string name, decimal price, double grams) : base(name, price, grams)
        {

        }
    }
    public class Cake : Dessert
    {
        const double grams = 250;
        public override double Grams { get => grams; }
        const double calories = 1000;
        public override double Calories { get =>calories; }
         const decimal cakePrice = 5;

        public override decimal Price { get => cakePrice; }
        public Cake(string name) : base(name,0,0,0)
        {
            this.Name = name;
        }

    }
    public class Fish:MainDish
    {
        const double grams = 22;
        public override double Grams { get => grams; }
        public Fish(string name, decimal price) : base(name, price, 0)
        {

        }
    }


}
