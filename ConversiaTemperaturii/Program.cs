using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversiaTemperaturii
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti temeratura in unitatea de masura celsius:");
            string input = Console.ReadLine();
            float celsiusToFahrenheit = float.Parse(input) * 9 / 5 + 32;
            Console.WriteLine("Temperatura in Fahrenheit este: " + celsiusToFahrenheit);
        }
    }
}
