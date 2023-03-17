using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanetWars.Models.MilitaryUnits
{
   public abstract class MilitaryUnit : IMilitaryUnit
    {
        private double cost;
        private int enduranceLevel;
      public double Cost 
        { 
            get => this.cost;
            private set 
            {
                cost = value;
            } 
        }
        public int EnduranceLevel => this.enduranceLevel;
        protected MilitaryUnit(double cost)
        {
            this.Cost = cost;
            this.enduranceLevel = 1;
        }

      

        public void IncreaseEndurance()
        {

            if (this.enduranceLevel == 20)
            {

                throw new ArgumentException(string.Format(ExceptionMessages.EnduranceLevelExceeded));
            }
            this.enduranceLevel++;
        }
    }
}
