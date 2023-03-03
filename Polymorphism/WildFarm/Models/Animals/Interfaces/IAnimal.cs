using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Food.Interfaces;

namespace WildFarm.Models.Animals.Interfaces
{
   public interface IAnimal
    {
        string Name { get; }

        double Weight { get; }

        int FoodEaten { get; }

        string ProduceSound();

        void Feed(IFood food);
    }
}
