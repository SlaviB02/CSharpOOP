using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public abstract class FormulaOneCar : IFormulaOneCar
    {
        private string model;
        private int horsePower;
        private double engineDisplacement;
protected FormulaOneCar(string model, int horsePower, double engineDisplacement)
        {
            this.model = model;
            this.horsePower = horsePower;
            this.engineDisplacement = engineDisplacement;
        }
        public string Model
        {
            get
            {
                return this.model;
            }
            private set
            {
                if(string.IsNullOrWhiteSpace(value)==true || value.Length<3)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1CarModel, value));
                }
                this.model = value;
            }
        }
        public int Horsepower
        {
            get
            {
                return this.horsePower;
            }
            private set
            {
                if(value<900 || value>1050)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1HorsePower, value));
                }
                this.horsePower = value;
            }

        }

        public double EngineDisplacement
        {
            get
            {
                return this.engineDisplacement;
            }
            private set
            {
                if(value<1.6 ||value>2.00)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidF1EngineDisplacement, value));
                }
            }
        }

        public double RaceScoreCalculator(int laps)
        {
            return this.engineDisplacement/this.horsePower*laps;
        }
    }
}
