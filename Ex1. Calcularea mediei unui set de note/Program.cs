using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1.Calcularea_mediei_unui_set_de_note
{
    internal class Program
    {
        public class InvalidGradeException : Exception
        {
            public InvalidGradeException(string message) : base(message)
            {
            }
        }

        static void Main(string[] args)
        {
            List<double> grades = new List<double>();
            const int numberOfGrades = 4;

            try
            {
                for (int i = 0; i < numberOfGrades; i++)
                {
                    Console.Write($"Introduceti nota {i + 1} (0-10): ");
                    string input = Console.ReadLine();

                    if (!double.TryParse(input, out double grade))
                    {
                        throw new InvalidGradeException("Eroare: Introduceti o valoare numerica!!!");
                    }

                    if (grade < 0 || grade > 10)
                    {
                        throw new InvalidGradeException($"Eroare: Nota {grade} nu este valida!!! Notele trebuie sa fie intre 0 si 10!!!");
                    }

                    grades.Add(grade);
                }

                double sum = 0;
                foreach (double grade in grades)
                {
                    sum += grade;
                }
                double average = sum / numberOfGrades;

                Console.WriteLine($"\nMedia notelor este: {average:F2}");
            }
            catch (InvalidGradeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"A aparut o eroare: {ex.Message}");
            }
        }
    }
}
