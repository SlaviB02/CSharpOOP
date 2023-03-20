﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UniversityCompetition.Models.Contracts;
using UniversityCompetition.Repositories.Contracts;

namespace UniversityCompetition.Repositories
{
    public class StudentRepository : IRepository<IStudent>
    {
        private List<IStudent> students;
        public StudentRepository()
        {
            this.students = new List<IStudent>();
        }
        public IReadOnlyCollection<IStudent> Models => this.students;

        public void AddModel(IStudent model)
        {
            this.students.Add(model);
        }

        public IStudent FindById(int id)
        {
            return this.Models.FirstOrDefault(x => x.Id == id);
        }

        public IStudent FindByName(string name)
        {
            string[] names = name.Split(" ");
            return this.Models.FirstOrDefault(x => x.FirstName== names[0] && x.LastName==names[1]);
        }
    }
}
