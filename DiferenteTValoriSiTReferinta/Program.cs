using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiferenteTValoriSiTReferinta
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Point point = new Point(10,20);
            Console.WriteLine($"Point la inceput:{point}");

            Point pointCopie = point;
            pointCopie.x = 30;
            pointCopie.y = 40;
            Console.WriteLine($"Point initial dupa modificare:{point}");
            Console.WriteLine($"Point copie dupa modificare:{pointCopie}");

            Console.WriteLine("-------------------------------------------------");

            Circle circle = new Circle(5, point);
            Console.WriteLine($"Circle initial:{circle}");
            Circle circleCopie = circle;
            circleCopie.Radius = 10;
            circleCopie.Center = new Point(20,30);
            Console.WriteLine($"Circle initial dupa modificare:{circle}");
            Console.WriteLine($"Circle copie dupa modificare:{circleCopie}");
        }

        public struct Point
        { 
                public int x;
                public int y;

               public Point(int x, int y)
               {
                   this.x = x;
                   this.y = y;
               }
               public override string ToString()
               {
                   return $"x:{x}, y:{y}";
               }
        }
        public class Circle
        {
            public int Radius { get; set; } 
            public Point Center { get; set; } 

            public Circle(int radius, Point center)
            {
                Radius = radius;
                Center = center;
            }

            public override string ToString() => $"Circle: Radius={Radius}, Center={Center}";
        }
    }
}
