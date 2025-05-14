using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluarea_calificativului_studenților
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti nota studentului!");
            int input = int.Parse(Console.ReadLine());

            if (input == 10)
            {
                Console.WriteLine("Excelent!");
            }
            else if (input == 8 || input == 9)
            {
                Console.WriteLine("Bun!");
            }
            else if (input >= 5 && input <= 7)
            {
                Console.WriteLine("Suficient!");
            }
            else if (input >=1 && input < 5)
            {
                Console.WriteLine("Insuficient!");
            }
            else
            {
                Console.WriteLine("Nota introdusa nu este valida.");
            }
        }
    }
}
