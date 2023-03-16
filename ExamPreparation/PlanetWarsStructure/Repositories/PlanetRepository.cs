using PlanetWars.Models.Planets.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> planets;
        public IReadOnlyCollection<IPlanet> Models => this.planets;

        public void AddItem(IPlanet model)
        {
            this.planets.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            var seachedUnit = this.planets.FirstOrDefault(x => x.GetType().Name == name);
            if (seachedUnit != null)
            {
                return seachedUnit;
            }
            return null;
        }

        public bool RemoveItem(string name)
        {
            var seachedUnit = this.planets.FirstOrDefault(x => x.GetType().Name == name);
            if (seachedUnit != null)
            {
                this.planets.Remove(seachedUnit);
                return true;
            }
            return false;
        }
    }
}
