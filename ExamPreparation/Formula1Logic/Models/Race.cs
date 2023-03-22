using Formula1.Models.Contracts;
using Formula1.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Formula1.Models
{
    public class Race : IRace
    {
        private string raceName;
        private int numberOfLaps;
        ICollection<IPilot> pilots;
        private bool tookPlace;

        public Race(string raceName, int numberOfLaps)
        {
            this.raceName = raceName;
            this.numberOfLaps = numberOfLaps;
            this.pilots = new List<IPilot>();
            this.tookPlace = false;
        }

        public string RaceName
        {
            get
            {
                return this.raceName;
            }
            private set
            {
                if(string.IsNullOrWhiteSpace(value)==true || value.Length<5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidRaceName, value));
                }
                this.raceName = value;
            }
        }

        public int NumberOfLaps
        {
            get
            {
                return this.numberOfLaps;
            }
            private set
            {
                if(value<1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidLapNumbers, value));
                }
                this.numberOfLaps = value;
            }
        }

        public bool TookPlace { get { return this.tookPlace; } set => this.tookPlace = value; }

        public ICollection<IPilot> Pilots => this.pilots;

        public void AddPilot(IPilot pilot)
        {
            this.pilots.Add(pilot);
        }

        public string RaceInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"The {this.raceName} race has:");
            sb.AppendLine($"Participants: {this.pilots.Count}");
            sb.AppendLine($"Number of laps: {this.numberOfLaps}");
            if(this.tookPlace==true)
            {
                sb.AppendLine($"Took place: Yes");
            }
            else
            {
                sb.AppendLine($"Took place: No");
            }
            return sb.ToString().Trim();
        }
    }
}
