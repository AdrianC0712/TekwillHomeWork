using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilizare_array_unidimensional
{
    internal class Program
    {
        public struct Angajati
        {
            public string NumeAngajat;
            public string DepartamentAngajat;
            public double SalariuAngajat;
        }
        public static int[] Array { get; set; }
        public static Angajati[] ArrayAngajati { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Selectati optiunea dorita:");
            Console.WriteLine("1. Notele unui grup de studenti!");
            Console.WriteLine("2. Angajatii unei companii!");
            int optiune = int.Parse(Console.ReadLine());

            switch (optiune)
            {
                case 1:
                    CompletareArray();
                    AfisareArray(Array);
                    double medie = CalculMedie(Array);
                    Console.WriteLine($"Media notelor este: {medie}");
                    break;
                case 2:
                    CompletareArrayAngajati();
                    double salariuMedie = CalculSalariuMediu(ArrayAngajati);
                    Console.WriteLine($"Salariul mediu al angajatilor este: {salariuMedie}");
                    AfiseazaAnagaziSalariuMediuMaiMare(ArrayAngajati);
                    break;
                default:
                    Console.WriteLine("Optiune invalida!");
                    break;
            }
        }

        static void CompletareArray()
        {
            Console.WriteLine("Introduceti numarul de studeti: ");
            int input = int.Parse(Console.ReadLine());

            int[] array = new int[input];

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Introduceti nota studentului {i + 1}: ");
                array[i] = int.Parse(Console.ReadLine());
            }

            Array = array;
        }

        static void AfisareArray(int[] array)
        {
            Console.WriteLine("Nota studentilor: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Nota studentului {i + 1}: {array[i]}");
            }
        }

        static double CalculMedie(int[] array)
        {
            double suma = 0;
            for (int i = 0; i < array.Length; i++)
            {
                suma += array[i];
            }
            return suma / array.Length;
        }
        static void CompletareArrayAngajati()
        {
            Angajati[] angajati = new Angajati[3];

            for (int i = 0; i < angajati.Length; i++)
            {
                Console.WriteLine($"Introduceti numele angajatului {i + 1}: ");
                angajati[i].NumeAngajat = Console.ReadLine();
                Console.WriteLine($"Introduceti departamentul angajatului {i + 1}: ");
                angajati[i].DepartamentAngajat = Console.ReadLine();
                Console.WriteLine($"Introduceti salariul angajatului {i + 1}: ");
                angajati[i].SalariuAngajat = double.Parse(Console.ReadLine());
            }
            ArrayAngajati = angajati;
        }
        static double CalculSalariuMediu(Angajati[] angajati)
        {
            double suma = 0;
            for (int i = 0; i < angajati.Length; i++)
            {
                suma += angajati[i].SalariuAngajat;
            }
            return suma / angajati.Length;
        }
        static void AfiseazaAnagaziSalariuMediuMaiMare(Angajati[] angajati)
        {
            for (int i = 0; i < ArrayAngajati.Length; i++)
            { 
                if(ArrayAngajati[i].SalariuAngajat > CalculSalariuMediu(ArrayAngajati))
                {
                    Console.WriteLine($"Angajatul {ArrayAngajati[i].NumeAngajat} are un salariu mai mare decat media!");
                }
            }
        }
    }
}
