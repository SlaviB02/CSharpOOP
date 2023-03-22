﻿using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Pilot : IPilot
    {
        private string fullName;
        private IFormulaOneCar car;
        private int numberOfWins;
        private bool canRace;

        public Pilot(string fullName)
        {
            this.FullName = fullName;
            this.canRace = false;
        }

        public string FullName
        {
            get
            {
                return this.fullName;
            }
            private set
            {
                if(string.IsNullOrWhiteSpace(value)==true || value.Length<5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPilot, value));
                }
                this.fullName = value;
            }
        }

        public IFormulaOneCar Car
        {
            get { return this.car; }
            private set
            {
                if(value==null)
                {
                    throw new NullReferenceException(string.Format(ExceptionMessages.InvalidCarForPilot));
                }
                this.car = value;
            }
        }

        public int NumberOfWins => this.numberOfWins;

        public bool CanRace => this.canRace;

        public void AddCar(IFormulaOneCar car)
        {
            this.Car = car;
            this.canRace = true;
        }

        public void WinRace()
        {
            this.numberOfWins++;
        }
        public override string ToString()
        {
            return $"Pilot {this.fullName} has {this.numberOfWins} wins.";
        }
    }
}
