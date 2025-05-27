using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptionalCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti primul nr:");
            string input1 = Console.ReadLine();
            Console.WriteLine("Introduceti al doilea nr:");
            string input2 = Console.ReadLine();
            Console.WriteLine("Introduceti operatia dorita:");
            string inputOperatie = Console.ReadLine();

            switch (inputOperatie)
            {
                case "+":
                    Console.WriteLine("Suma este: " + (float.Parse(input1) + float.Parse(input2)));
                    break;
                case "-":
                    Console.WriteLine("Diferenta este: " + (float.Parse(input1) - float.Parse(input2)));
                    break;
                case "*":
                    Console.WriteLine("Produsul este: " + (float.Parse(input1) * float.Parse(input2)));
                    break;
                case "/":
                    if (float.Parse(input2) != 0)
                    {
                        Console.WriteLine("Catul este: " + (float.Parse(input1) / float.Parse(input2)));
                    }
                    else
                    {
                        Console.WriteLine("Impartirea la 0 nu este permisa.");
                    }
                    break;
                default:
                    Console.WriteLine("Operatia nu este valida.");
                    break;
            }

        }
    }
}
