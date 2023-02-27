using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
  public class Rogue:BaseHero
    {
        private int power = 80;
        public Rogue(string name) : base(name)
        {

        }
        public override int Power => this.power;
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} hit for {Power} damage";
        }
    }
}
