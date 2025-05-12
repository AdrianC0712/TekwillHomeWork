using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionareaDataNastere
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti data de nastere (format: dd/mm/yyyy):");
            string input = Console.ReadLine();
            DateTime birthDate;
            if (DateTime.TryParse(input, out birthDate))
            {
                DateTime today = DateTime.Today;
                int age = today.Year - birthDate.Year;
                if (birthDate > today.AddYears(-age))
                {
                    age--;
                }
                Console.WriteLine($"Ai {age} ani.");
            }
            else
            {
                Console.WriteLine("Data introdusa nu este valida.");
            }
        }
    }
}
