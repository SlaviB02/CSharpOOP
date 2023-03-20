using System;
using System.Collections.Generic;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Models
{
    public class Student : IStudent
    {
        private int id;
        private string firstName;
        private string lastName;
        private List<int> coveredExams;

        public Student(int id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.coveredExams = new List<int>();
        }

        public int Id { get { return this.id; }private set { this.id = value; } }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if(string.IsNullOrWhiteSpace(value)==true)
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                this.firstName = value;
            }
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) == true)
                {
                    throw new ArgumentException(ExceptionMessages.NameNullOrWhitespace);
                }
                this.lastName = value;
            }
        }

        public IReadOnlyCollection<int> CoveredExams => this.coveredExams;

        public IUniversity University { get; private set; }

        public void CoverExam(ISubject subject)
        {
            this.coveredExams.Add(subject.Id);
        }

        public void JoinUniversity(IUniversity university)
        {
            this.University = university;
        }
    }
}
