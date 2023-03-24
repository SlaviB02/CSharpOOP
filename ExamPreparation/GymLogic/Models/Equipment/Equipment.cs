using Gym.Models.Equipment.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gym.Models.Equipment
{
    public abstract class Equipment : IEquipment
    {
        private double weight;
        private decimal price;

        protected Equipment(double weight, decimal price)
        {
            this.weight = weight;
            this.price = price;
        }

        public double Weight { get { return this.weight; }private set { this.weight = value; } }

        public decimal Price { get { return this.price; }private set { this.price = value; } }
    }
}
