using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        private EquipmentRepository equipment;
        private List<IGym> gyms;
        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }
        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            if(athleteType!=nameof(Boxer) && athleteType!=nameof(Weightlifter))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidAthleteType));
            }
            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);
            IAthlete athlete;
            if(athleteType==nameof(Boxer))
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
                if(gym.GetType().Name!=nameof(BoxingGym))
                {
                    return string.Format(OutputMessages.InappropriateGym);
                }
            }
            else
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                if (gym.GetType().Name != nameof(WeightliftingGym))
                {
                    return string.Format(OutputMessages.InappropriateGym);
                }
            }
            gym.AddAthlete(athlete);
            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            

        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment;
            if (equipmentType != nameof(BoxingGloves) && equipmentType != nameof(Kettlebell))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidEquipmentType));
            }
            if (equipmentType == nameof(BoxingGloves))
            {
                equipment = new BoxingGloves();
            }
            else
            {
                equipment = new Kettlebell();
            }
            this.equipment.Add(equipment);
            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym;
            if(gymType!=nameof(BoxingGym) && gymType!=nameof(WeightliftingGym))
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InvalidGymType));
            }
            if(gymType==nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
            }
            else
            {
                gym = new WeightliftingGym(gymName);
            }
            this.gyms.Add(gym);
            return string.Format(OutputMessages.SuccessfullyAdded, gym.GetType().Name);
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);
            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, gym.EquipmentWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = this.equipment.FindByType(equipmentType);
            if(equipment==default)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }
            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);
            gym.AddEquipment(equipment);
            this.equipment.Remove(equipment);
            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            foreach(var gym in gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }
            return sb.ToString().Trim();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(x => x.Name == gymName);
            gym.Exercise();
            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}
