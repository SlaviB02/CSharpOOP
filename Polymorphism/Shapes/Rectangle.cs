﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
   public class Rectangle:Shape
    {
        private double height;
        private double width;

        public Rectangle(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height { get; private set; }
        public double Width { get; private set; }

        public override double CalculatePerimeter()
        {
            return 2 * this.Height + 2 * this.Width;
        }
        public override double CalculateArea()
        {
            return this.Height*this.Width;
        }
        public override string Draw()
        {
            return base.Draw()+this.GetType().Name;
        }
    }
}
