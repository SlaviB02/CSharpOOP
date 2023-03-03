using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food.Interfaces;

namespace WildFarm.Models.Food
{
    public abstract class Food:IFood
    {
        public int Quantity { get; private set; }
        protected Food(int quantity)
        {
            this.Quantity = quantity;
        }
    }
}
