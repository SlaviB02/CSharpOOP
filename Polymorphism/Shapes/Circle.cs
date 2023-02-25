﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
   public class Circle:Shape
    {
        private double radius;
        public double Radius { get; private set; }
        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public override double CalculatePerimeter()
        {
            return 2 * Math.PI * this.Radius;
        }
        public override double CalculateArea()
        {
            return Math.PI * this.Radius * this.Radius;
        }
        public override string Draw()
        {
            return base.Draw()+this.GetType().Name;
        }
    }

}
