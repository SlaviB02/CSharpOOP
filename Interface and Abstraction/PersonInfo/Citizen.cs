﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
   public class Citizen:IPerson,IBirthable,IIdentifiable
    {
        private string name;
        private int age;
        private string birthDate;
        private string id;
        public string Birthdate { get; private set; }
        public string Id { get; private set; }
        public Citizen(string name, int age,string id,string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
            this.Id = id;
        }

        public string Name { get; private set; }
        public int Age { get; private set; }

    }
}
