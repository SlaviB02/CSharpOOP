using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
    public class Druid:BaseHero
    {
        private int power = 80;
        public Druid(string name):base(name)
        {

        }
        public override int Power => this.power;
        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {Name} healed for {Power}";
        }
    }
}
