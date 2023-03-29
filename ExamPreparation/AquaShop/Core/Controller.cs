using AquaShop.Core.Contracts;
using AquaShop.Models.Aquariums;
using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish;
using AquaShop.Models.Fish.Contracts;
using AquaShop.Repositories;
using AquaShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Core
{
    public class Controller : IController
    {
        private DecorationRepository decorations;
        private List<IAquarium> aquariums;
        public Controller()
        {
            this.decorations = new DecorationRepository();
            this.aquariums = new List<IAquarium>();
        }
        public string AddAquarium(string aquariumType, string aquariumName)
        {
           
            if(aquariumType!=nameof(SaltwaterAquarium) && aquariumType!=nameof(FreshwaterAquarium))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAquariumType));
            }
            IAquarium aquarium;
            if (aquariumType==nameof(SaltwaterAquarium))
            {
                aquarium = new SaltwaterAquarium(aquariumName);
            }
            else
            {
                aquarium = new FreshwaterAquarium(aquariumName);
            }
            this.aquariums.Add(aquarium);
            return string.Format(OutputMessages.SuccessfullyAdded, aquariumType);
        }

        public string AddDecoration(string decorationType)
        {
            if(decorationType!=nameof(Ornament) && decorationType!=nameof(Plant))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidDecorationType));
            }
            IDecoration decoration;
            if(decorationType==nameof(Ornament))
            {
                decoration = new Ornament();
            }
            else
            {
                decoration = new Plant();
            }
            this.decorations.Add(decoration);
            return string.Format(OutputMessages.SuccessfullyAdded, decorationType);
        }

        public string AddFish(string aquariumName, string fishType, string fishName, string fishSpecies, decimal price)
        {
            IFish fish;
            if(fishType!=nameof(FreshwaterFish) && fishType!=nameof(SaltwaterFish))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidFishType));
            }
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            if (fishType==nameof(FreshwaterFish))
            {
                if (aquarium.GetType().Name != nameof(FreshwaterAquarium))
                {
                    return string.Format(OutputMessages.UnsuitableWater);
                }
                fish = new FreshwaterFish(fishName, fishSpecies, price);
                
            }
            else
            {
                if (aquarium.GetType().Name != nameof(SaltwaterAquarium))
                {
                    return string.Format(OutputMessages.UnsuitableWater);
                }
                fish = new SaltwaterFish(fishName, fishSpecies, price);
            }
            aquarium.AddFish(fish);
            return string.Format(OutputMessages.EntityAddedToAquarium,fishType,aquariumName);

        }

        public string CalculateValue(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            decimal sum = 0;
            foreach(var f in aquarium.Fish)
            {
                sum += f.Price;
            }
            foreach(var d in aquarium.Decorations)
            {
                sum += d.Price;
            }
            return string.Format(OutputMessages.AquariumValue,aquariumName,sum);
        }

        public string FeedFish(string aquariumName)
        {
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.Feed();
            return string.Format(OutputMessages.FishFed, aquarium.Fish.Count);
        }

        public string InsertDecoration(string aquariumName, string decorationType)
        {
            var seachedDecoration = this.decorations.FindByType(decorationType);
            if(seachedDecoration==null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentDecoration,decorationType));
            }
            var aquarium = this.aquariums.FirstOrDefault(x => x.Name == aquariumName);
            aquarium.AddDecoration(seachedDecoration);
            this.decorations.Remove(seachedDecoration);
            return string.Format(OutputMessages.EntityAddedToAquarium, decorationType,aquariumName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var aq in this.aquariums)
            {
                sb.AppendLine(aq.GetInfo());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
