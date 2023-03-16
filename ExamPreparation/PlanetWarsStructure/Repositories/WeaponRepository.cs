using PlanetWars.Models.Weapons.Contracts;
using PlanetWars.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlanetWars.Repositories
{
    public class WeaponRepository : IRepository<IWeapon>
    {
        private List<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }
        public IReadOnlyCollection<IWeapon> Models => this.weapons;

        public void AddItem(IWeapon model)
        {
            this.weapons.Add(model);
        }

        public IWeapon FindByName(string name)
        {
            var seachedWeapon = this.weapons.FirstOrDefault(x => x.GetType().Name == name);
            if(seachedWeapon!=null)
            {
                return seachedWeapon;
            }
            return null;
        }

        public bool RemoveItem(string name)
        {
            var seachedWeapon = this.weapons.FirstOrDefault(x => x.GetType().Name == name);
            if(seachedWeapon!=null)
            {
                this.weapons.Remove(seachedWeapon);
                return true;
            }
            return false;
        }
    }


}
