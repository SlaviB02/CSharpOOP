using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding
{
   public abstract class BaseHero
    {
        public string Name { get; set; }
        public abstract int Power { get;}
        public BaseHero(string name)
        {
            this.Name = name;
        }
        public abstract string CastAbility();
       
    }
}
