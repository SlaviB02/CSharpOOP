using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        private List<IDecoration> decorations;
        private List<IFish> fish;

        protected Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            this.decorations = new List<IDecoration>();
            this.fish = new List<IFish>();
        }

        public string Name { get { return this.name; }
        private set
            {
                if(string.IsNullOrWhiteSpace(value)==true)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidAquariumName));
                }
                this.name = value;
            }
}

        public int Capacity { get { return this.capacity; }private set { this.capacity = value; } }

        public int Comfort => this.decorations.Sum(x => x.Comfort);

        public ICollection<IDecoration> Decorations => this.decorations;

        public ICollection<IFish> Fish => this.fish;

        public void AddDecoration(IDecoration decoration)
        {
            this.decorations.Add(decoration);
        }

        public void AddFish(IFish fish)
        {
            if(this.capacity>this.fish.Count)
            {
                this.fish.Add(fish);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NotEnoughCapacity));
            }

        }

        public void Feed()
        {
            foreach(var f in this.fish)
            {
                f.Eat();
            }
        }

        public string GetInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.name} ({this.GetType().Name}):");
            if(fish.Count==0)
            {
                sb.AppendLine($"Fish: none");
            }
            else
            {
                List<string> names = new List<string>();
                foreach(var f in fish)
                {
                    names.Add(f.Name);
                }
                sb.AppendLine($"Fish: "+string.Join(", ", names));
            }
            sb.AppendLine($"Decorations: {this.decorations.Count}");
            sb.AppendLine($"Comfort: {this.Comfort}");
            return sb.ToString().TrimEnd();
        }

        public bool RemoveFish(IFish fish)
        {
            return this.fish.Remove(this.fish.FirstOrDefault(x =>x.Name == fish.Name));
        }
    }
}
