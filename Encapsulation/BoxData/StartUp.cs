using System;
using System.Collections.Generic;
using System.Text;

namespace BoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            Box box = null;
            try
            {
                box = new Box(length, width, height);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            Console.WriteLine($"Surface Area - {box.SurfaceArea():F2}");
            Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():F2}");
            Console.WriteLine($"Volume - {box.Volume():F2}");
        }
    }
}
