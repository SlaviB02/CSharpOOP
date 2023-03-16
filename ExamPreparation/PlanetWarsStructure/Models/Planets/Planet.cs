using PlanetWars.Models.MilitaryUnits;
using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Models.Weapons;
using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories;
using PlanetWars.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Models.Planets
{
    public class Planet : IPlanet
    {
        private string name;
        private double budget;
        private double militaryPower;
        private UnitRepository units;
        private WeaponRepository weapons;

        public Planet(string name, double budget)
        {
            this.Name = name;
            this.Budget = budget;
            this.units = new UnitRepository();
            this.weapons = new WeaponRepository();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if(string.IsNullOrWhiteSpace(value)==true)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidPlanetName));
                }
                this.name = value;
            }
        }

        public double Budget
        {
            get
            {
                return this.budget;
            }
            private set
            {
                if(value<0)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidBudgetAmount));
                }
                this.budget = value;
            }
        }

        public double MilitaryPower => Math.Round(this.CalculateMilitaryPower(), 3);

        public IReadOnlyCollection<IMilitaryUnit> Army => this.units.Models;

        public IReadOnlyCollection<IWeapon> Weapons => this.weapons.Models;

        public void AddUnit(IMilitaryUnit unit)
        {
            this.units.AddItem(unit);
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.AddItem(weapon);
        }

        public string PlanetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Planet: {this.Name}");
            sb.AppendLine($"--Budget: {this.Budget} billion QUID");
            sb.Append($"--Forces: ");
            if (this.Army.Count == 0)
            {
                sb.AppendLine("No units");
            }
            else
            {
                List<string> names = new List<string>();
                foreach(var unit in this.Army)
                {
                    names.Add(unit.GetType().Name);
                }
                sb.AppendLine(string.Join(", ", names));
            }
            sb.Append($"--Combat equipment: ");

            if (this.Weapons.Count == 0)
            {
                sb.AppendLine("No weapons");
            }
            else
            {
                List<string> names = new List<string>();
                foreach (var unit in this.Weapons)
                {
                    names.Add(unit.GetType().Name);
                }
                sb.AppendLine(string.Join(", ", names));
            }
            sb.AppendLine($"--Military Power: {this.MilitaryPower}");

            return sb.ToString().Trim();
        }

        public void Profit(double amount)
        {
            this.budget += amount;
        }

        public void Spend(double amount)
        {
            if (amount > this.Budget)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.UnsufficientBudget));
            }
            this.Budget -= amount;
        }

        public void TrainArmy()
        {
            foreach(var unit in this.Army)
            {
                unit.IncreaseEndurance();
            }
        }
        private double CalculateMilitaryPower()
        {
            double total = this.units.Models.Sum(x => x.EnduranceLevel) + this.weapons.Models.Sum(x => x.DestructionLevel);
            if (this.units.Models.Any(x => x.GetType().Name == nameof(AnonymousImpactUnit)))
            {
                total *= 1.30;
            }
            if(this.units.Models.Any(x => x.GetType().Name == nameof(NuclearWeapon)))
            {
                total *= 1.45;
            }
            return total;
        }
    }
}
