using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Core.Contracts;
using UniversityCompetition.Models;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories;
using UniversityCompetition.Utilities.Messages;

namespace UniversityCompetition.Core
{
    public class Controller : IController
    {
        private SubjectRepository subjects;
        private StudentRepository students;
        private UniversityRepository universities;

        public Controller()
        {
            this.subjects = new SubjectRepository();
            this.students = new StudentRepository();
            this.universities = new UniversityRepository();
        }

        public string AddStudent(string firstName, string lastName)
        {
            
            if(this.students.FindByName($"{firstName} {lastName}")!=default)
            {
                return string.Format(OutputMessages.AlreadyAddedStudent, firstName, lastName);
            }
            else
            {
                IStudent student = new Student(this.students.Models.Count + 1, firstName, lastName);
                this.students.AddModel(student);
                return string.Format(OutputMessages.StudentAddedSuccessfully, firstName, lastName, nameof(StudentRepository));
            }
        }

        public string AddSubject(string subjectName, string subjectType)
        {
            if (subjectType != nameof(TechnicalSubject) && subjectType != nameof(HumanitySubject) && subjectType != nameof(EconomicalSubject))
            {
                return string.Format(OutputMessages.SubjectTypeNotSupported, subjectType);
            }
            else if (this.subjects.FindByName(subjectName) != default)
            {
                return string.Format(OutputMessages.AlreadyAddedSubject, subjectName);
            }
            else
            {
                ISubject subject;
                if (subjectType == nameof(TechnicalSubject))
                {
                    subject = new TechnicalSubject(this.subjects.Models.Count + 1, subjectName);
                }
                else if (subjectType == nameof(HumanitySubject))
                {
                    subject = new HumanitySubject(this.subjects.Models.Count + 1, subjectName);
                }
                else
                {
                    subject = new EconomicalSubject(this.subjects.Models.Count + 1, subjectName);
                }
                this.subjects.AddModel(subject);
                return string.Format(OutputMessages.SubjectAddedSuccessfully, subjectType, subjectName, nameof(SubjectRepository));
            }
        }

        public string AddUniversity(string universityName, string category, int capacity, List<string> requiredSubjects)
        {
            if (this.universities.FindByName(universityName) != default)
            {
                return string.Format(OutputMessages.AlreadyAddedUniversity,universityName);
            }
            else
            {
                List<int> required = new List<int>();
                foreach(var item in requiredSubjects)
                {
                    required.Add(this.subjects.FindByName(item).Id);
                }
                IUniversity university = new University(this.universities.Models.Count + 1, universityName, category, capacity, required);
                this.universities.AddModel(university);
                return string.Format(OutputMessages.UniversityAddedSuccessfully, universityName, nameof(UniversityRepository));
            }
        }

        public string ApplyToUniversity(string studentName, string universityName)
        {
            string[] names = studentName.Split(" ");
            var student = this.students.FindByName(studentName);
            var university = this.universities.FindByName(universityName);
            if (student == default)
            {
                return string.Format(OutputMessages.StudentNotRegitered, names[0], names[1]);
            }
            else if (university == default)
            {
                return string.Format(OutputMessages.UniversityNotRegitered, universityName);
            }
            else if (!university.RequiredSubjects.All(x => student.CoveredExams.Any(e => e == x)))
            {
                return string.Format(OutputMessages.StudentHasToCoverExams, studentName, universityName);
            }
            else if (student.University == university)
            {
                return string.Format(OutputMessages.StudentAlreadyJoined, names[0], names[1], universityName);
            }
            else
            {
                student.JoinUniversity(university);
                return string.Format(OutputMessages.StudentSuccessfullyJoined, names[0], names[1], universityName);
            }
            
        }

        public string TakeExam(int studentId, int subjectId)
        {
           if(this.students.FindById(studentId)==default)
            {
                return string.Format(OutputMessages.InvalidStudentId);
            }
           else if(this.subjects.FindById(subjectId)==default)
            {
                return string.Format(OutputMessages.InvalidSubjectId);
            }
            
            else if(students.FindById(studentId).CoveredExams.Any(e => e == subjectId))
            {
                return string.Format(OutputMessages.StudentAlreadyCoveredThatExam, students.FindById(studentId).FirstName,
                    students.FindById(studentId).LastName,
                    subjects.FindById(subjectId).Name);
            }
           else
            {
                var student = this.students.FindById(studentId);
                var subject = this.subjects.FindById(subjectId);

                student.CoverExam(subject);
                return string.Format(OutputMessages.StudentSuccessfullyCoveredExam, student.FirstName, student.LastName, subject.Name);
            }
            
        }

        public string UniversityReport(int universityId)
        {
            var university = this.universities.FindById(universityId);
            int studentCount = this.students.Models.Where(x => x.University == university).Count();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"*** {university.Name} ***");
            sb.AppendLine($"Profile: {university.Category}");
            sb.AppendLine($"Students admitted: {studentCount}");
            sb.AppendLine($"University vacancy: {university.Capacity-studentCount}");
            return sb.ToString().Trim();
        }
    }
}
