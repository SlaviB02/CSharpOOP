using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingSpree
{
   public class Person
    {
        private string name;
        private double money;
        private List<Product> bagOfProducts;
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public double Money
        {
            get
            {
                return this.money;
            }
             set
            {
                if(value<0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }
        public Person(string name,double money)
        {
            this.Name = name;
            this.Money = money;
            this.BagOfProducts = new List<Product>();
        }

        public List<Product> BagOfProducts { 
            get
            {
                return this.bagOfProducts;
            }
            set
            {
                this.bagOfProducts = value;
            }
        }
    }
}
