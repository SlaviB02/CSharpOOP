using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using SpaceStation.Models.Planets.Contracts;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using SpaceStation.Models.Mission;


namespace SpaceStation.Core
{
   
    public class Controller : IController
    {
        private int exploredPlanets=0;
        private AstronautRepository astronauts;
        private PlanetRepository planets;
        public Controller()
        {
            this.astronauts = new AstronautRepository();
            this.planets = new PlanetRepository();        
        }
        public string AddAstronaut(string type, string astronautName)
        {
            IAstronaut astronaut;
            if(type!=nameof(Biologist) && type!=nameof(Geodesist) && type!=nameof(Meteorologist))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAstronautType));
            }
            if(type==nameof(Biologist))
            {
                astronaut = new Biologist(astronautName);
            }
            else if(type==nameof(Geodesist))
            {
                astronaut = new Geodesist(astronautName);
            }
            else
            {
                astronaut = new Meteorologist(astronautName);
            }
            this.astronauts.Add(astronaut);
            return string.Format(OutputMessages.AstronautAdded, type, astronautName);
            
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            IPlanet planet = new Planet(planetName);
            foreach(var item in items)
            {
                planet.Items.Add(item);
            }
            this.planets.Add(planet);
            return string.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string ExplorePlanet(string planetName)
        {
            var astronautsToSend = this.astronauts.Models.Where(x => x.Oxygen > 60).ToList();
            if(astronautsToSend.Count==0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAstronautCount));
            }
            Mission mission = new Mission();
            IPlanet planet = this.planets.FindByName(planetName);
            mission.Explore(planet, astronautsToSend);
            var deadAstronauts = astronautsToSend.Where(x => x.CanBreath == false).ToList();
            exploredPlanets++;
            return string.Format(OutputMessages.PlanetExplored, planetName, deadAstronauts.Count);

        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{exploredPlanets} planets were explored!");
            sb.AppendLine($"Astronauts info:");
            foreach(var ast in this.astronauts.Models)
            {
                sb.AppendLine($"Name: {ast.Name}");
                sb.AppendLine($"Oxygen: {ast.Oxygen}");
                if(ast.Bag.Items.Count==0)
                {
                    sb.AppendLine("Bag items: " + "none");
                }
                else
                {
                    sb.AppendLine("Bag items: " + string.Join(", ", ast.Bag.Items));
                }
            }
            return sb.ToString().Trim();
        }

        public string RetireAstronaut(string astronautName)
        {
            IAstronaut astronaut = this.astronauts.FindByName(astronautName);
            if(astronaut==null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            this.astronauts.Remove(astronaut);
            return string.Format(OutputMessages.AstronautRetired, astronautName);
        }
    }
}
