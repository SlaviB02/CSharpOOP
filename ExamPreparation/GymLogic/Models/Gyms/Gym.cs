using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Models.Gyms
{
    public abstract class Gym : IGym
    {
        private string name;
        private int capacity;
        private List<IEquipment> equipment;
        private List<IAthlete> athletes;

        protected Gym(string name, int capacity)
        {
            this.Name = name;
            this.capacity = capacity;
            this.equipment = new List<IEquipment>();
            this.athletes = new List<IAthlete>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if(string.IsNullOrEmpty(value)==true)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidGymName));
                }
                this.name = value;
            }
        }

        public int Capacity => this.capacity;

        public double EquipmentWeight => this.equipment.Sum(x => x.Weight);

        public ICollection<IEquipment> Equipment => this.equipment;

        public ICollection<IAthlete> Athletes => this.athletes;

        public void AddAthlete(IAthlete athlete)
        {
            if(this.athletes.Count<this.capacity)
            {
                this.athletes.Add(athlete);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotEnoughSize));
            }
        }

        public void AddEquipment(IEquipment equipment)
        {
            this.equipment.Add(equipment);
        }
        public void Exercise()
        {
            foreach(var athlete in this.athletes)
            {
                athlete.Exercise();
            }
        }

        public string GymInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.name} is a {this.GetType().Name}:");
            if(this.athletes.Count==0)
            {
                sb.AppendLine($"Athletes: No athletes");
            }
            else

            {
                
                List<string> names = new List<string>();
                foreach (var athlete in athletes)
                {
                    names.Add(athlete.FullName);
                }
                sb.AppendLine($"Athletes: " + string.Join(", ", names));
            }
            sb.AppendLine($"Equipment total count: {this.equipment.Count}");
            sb.AppendLine($"Equipment total weight: {this.EquipmentWeight:F2} grams");
            return sb.ToString().Trim();

        }

        public bool RemoveAthlete(IAthlete athlete)
        {
            return this.athletes.Remove(this.athletes.FirstOrDefault(x => x.FullName == athlete.FullName));
        }
    }
}
