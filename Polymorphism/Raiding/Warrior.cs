using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
   public class Warrior:BaseHero
    {
        private int power = 100;
        public Warrior(string name) : base(name)
        {

        }
        public override int Power => this.power;
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
