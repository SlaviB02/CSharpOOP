using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Repositories
{
    public class FormulaOneCarRepository : IRepository<IFormulaOneCar>
    {
        private List<IFormulaOneCar> cars;
        public FormulaOneCarRepository()
        {
            this.cars = new List<IFormulaOneCar>();
        }
        public IReadOnlyCollection<IFormulaOneCar> Models => this.cars;

        public void Add(IFormulaOneCar model)
        {
            this.cars.Add(model);
        }

        public IFormulaOneCar FindByName(string name)
        {
            return this.cars.FirstOrDefault(x => x.Model == name);
        }

        public bool Remove(IFormulaOneCar model)
        {
            return this.cars.Remove(this.cars.FirstOrDefault(x => x.Model == model.Model));
        }
    }
}
