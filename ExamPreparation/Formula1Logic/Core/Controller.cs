using Formula1.Core.Contracts;
using Formula1.Models;
using Formula1.Models.Contracts;
using Formula1.Repositories;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Formula1.Core
{
    public class Controller : IController
    {
        private PilotRepository pilotRepository;
        private RaceRepository raceRepository;
        private FormulaOneCarRepository formulaOneCarRepository;

        public Controller()
        {
            this.pilotRepository = new PilotRepository();
            this.raceRepository = new RaceRepository();
            this.formulaOneCarRepository = new FormulaOneCarRepository();
        }


        public string AddCarToPilot(string pilotName, string carModel)
        {
            var pilot = this.pilotRepository.FindByName(pilotName);
            if(pilot==null || pilot.CanRace==true)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistOrHasCarErrorMessage, pilotName));
            }
            var car = this.formulaOneCarRepository.FindByName(carModel);
            if (car==null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.CarDoesNotExistErrorMessage, carModel));
            }
            pilot.AddCar(car);
            this.formulaOneCarRepository.Remove(car);
            return string.Format(OutputMessages.SuccessfullyPilotToCar, pilotName, car.GetType().Name, carModel);            
        }

        public string AddPilotToRace(string raceName, string pilotFullName)
        {
            var race = this.raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new NullReferenceException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            var pilot = this.pilotRepository.FindByName(pilotFullName);
            if(pilot==null || pilot.CanRace==false || race.Pilots.Contains(pilot)==true)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotDoesNotExistErrorMessage, pilotFullName));
            }
            race.AddPilot(pilot);
            return string.Format(OutputMessages.SuccessfullyAddPilotToRace, pilotFullName, raceName);

        }

        public string CreateCar(string type, string model, int horsepower, double engineDisplacement)
        {
            var car = this.formulaOneCarRepository.FindByName(model);
            if (car != null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.CarExistErrorMessage, model));
            }
            if(type!=nameof(Ferrari) && type!=nameof(Williams))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidTypeCar, type));
            }
            IFormulaOneCar f1Car;
            if(type==nameof(Ferrari))
            {
                f1Car = new Ferrari(model,horsepower,engineDisplacement);
            }
            else
            {
                f1Car = new Williams(model, horsepower, engineDisplacement);
            }
            this.formulaOneCarRepository.Add(f1Car);
            return string.Format(OutputMessages.SuccessfullyCreateCar, type, model);
        }

        public string CreatePilot(string fullName)
        {
            var pilot = this.pilotRepository.FindByName(fullName);
            if(pilot!=default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.PilotExistErrorMessage, fullName));
            }
            IPilot p = new Pilot(fullName);
            this.pilotRepository.Add(p);
            return string.Format(OutputMessages.SuccessfullyCreatePilot, fullName);
        }

        public string CreateRace(string raceName, int numberOfLaps)
        {
            var race = this.raceRepository.FindByName(raceName);
            if(race!=null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceExistErrorMessage, raceName));
            }
            IRace race1 = new Race(raceName, numberOfLaps);
            this.raceRepository.Add(race1);
            return string.Format(OutputMessages.SuccessfullyCreateRace, raceName);
        }

        public string PilotReport()
        {
            var orderedPilots = this.pilotRepository.Models.OrderByDescending(x => x.NumberOfWins).ToList();
            StringBuilder sb = new StringBuilder();
            foreach(var pilot in orderedPilots)
            {
                sb.AppendLine(pilot.ToString());
            }
            return sb.ToString().Trim();
        }

        public string RaceReport()
        {
            StringBuilder sb = new StringBuilder();
            var executedRaces = this.raceRepository.Models.Where(x => x.TookPlace == true).ToList();
            foreach(var race in executedRaces)
            {
                sb.AppendLine(race.RaceInfo());
            }
            return sb.ToString().Trim();
            
        }

        public string StartRace(string raceName)
        {
            var race = this.raceRepository.FindByName(raceName);
            if (race == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceDoesNotExistErrorMessage, raceName));
            }
            if(race.Pilots.Count<3)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidRaceParticipants, raceName));
            }
            if(race.TookPlace==true)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.RaceTookPlaceErrorMessage, raceName));
            }
            var fastestRacers = race.Pilots.OrderByDescending(x => x.Car.RaceScoreCalculator(race.NumberOfLaps)).ToList();
            fastestRacers[0].WinRace();
            race.TookPlace = true;
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Pilot {fastestRacers[0].FullName} wins the {raceName} race.");
            sb.AppendLine($"Pilot {fastestRacers[1].FullName} is second in the {raceName} race.");
            sb.AppendLine($"Pilot {fastestRacers[2].FullName} is third in the {raceName} race.");
            return sb.ToString().Trim();
        }
    }
}
