using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl
{
   public class Robot:IId
    {
        private string id;
        private string model;

        public Robot(string model,string id)
        {
            this.Model = model;
            this.Id = id; 
        }

        public string Id { get; private set; }
        public string Model { get; private set; }

    }
}
