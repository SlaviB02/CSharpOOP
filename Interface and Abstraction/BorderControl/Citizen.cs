using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
   public class Citizen:IId
    {
        private string id;
        private string name;
        private int age;

        public Citizen(string name, int age,string id)
        {
           
            this.Name = name;
            this.Age = age;
            this.Id = id;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public int Age { get; private set; }
        
    }
}
