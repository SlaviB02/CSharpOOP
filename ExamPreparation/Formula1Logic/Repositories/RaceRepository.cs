using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
   public class RaceRepository : IRepository<IRace>
    {
        private List<IRace> races;
        public IReadOnlyCollection<IRace> Models => this.races;
        public RaceRepository()
        {
            this.races = new List<IRace>();
        }

        public void Add(IRace model)
        {
            this.races.Add(model);
        }

        public IRace FindByName(string name)
        {
            return this.races.FirstOrDefault(x => x.RaceName == name);
        }

        public bool Remove(IRace model)
        {
            return this.races.Remove(this.races.FirstOrDefault(x => x.RaceName == model.RaceName));
        }
    }
}
