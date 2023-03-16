using PlanetWars.Models.MilitaryUnits.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class UnitRepository : IRepository<IMilitaryUnit>
    {
        private List<IMilitaryUnit> units;

        public UnitRepository()
        {
            this.units = new List<IMilitaryUnit>();
        }

        public IReadOnlyCollection<IMilitaryUnit> Models => this.units; 

        public void AddItem(IMilitaryUnit model)
        {
            this.units.Add(model);
        }

        public IMilitaryUnit FindByName(string name)
        {
            var seachedUnit = this.units.FirstOrDefault(x => x.GetType().Name == name);
            if (seachedUnit != null)
            {
                return seachedUnit;
            }
            return null;
        }

        public bool RemoveItem(string name)
        {
            var seachedUnit = this.units.FirstOrDefault(x => x.GetType().Name == name);
            if (seachedUnit != null)
            {
                this.units.Remove(seachedUnit);
                return true;
            }
            return false;
        }
    }
}
