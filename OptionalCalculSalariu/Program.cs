using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OptionalCalculSalariu
{
    internal class Program
    {
        public static string SalariuBrut { get; set; } 
        public static string ConvertToUSDValue { get; set; }
        public static string CategorieImpozitare { get; set; }
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti numele angajatului:");
            string nume = Console.ReadLine();
            Console.WriteLine("Introduceti salariul brut:");
            string inputSalariuBrut = Console.ReadLine();
            SalariuBrut = inputSalariuBrut;
            Console.WriteLine("Introduceti rata de schimb a monedei locale in raport cu USD:");
            string inputConvertToUSD = Console.ReadLine();
            ConvertToUSDValue = inputConvertToUSD;
            Console.WriteLine("Introduceti categoria de impozitare:");
            string inputCategorieImpozitare = Console.ReadLine();
            CategorieImpozitare = inputCategorieImpozitare;

            VerificaSalariuMediu();
        }

        public static float CalculSalariuBrutToNet(float salariuBrut, int categorieImpozitare)
        {
            salariuBrut = float.Parse(SalariuBrut);
            categorieImpozitare = int.Parse(CategorieImpozitare);
            float salariuNet = 0;
            switch (categorieImpozitare)
            {
                case 1:
                    salariuNet = salariuBrut - (salariuBrut * 0.10f);
                    break;
                case 2:
                    salariuNet = salariuBrut - (salariuBrut * 0.20f);
                    break;
                case 3:
                    salariuNet = salariuBrut - (salariuBrut * 0.30f);
                    break;
                default:
                    Console.WriteLine("Categoria de impozitare nu este valida.");
                    break;
            }
            return salariuNet;
        }

        public static float ConvertToUSD(float salariuNet, float convertToUSD)
        {
            salariuNet = CalculSalariuBrutToNet(float.Parse(SalariuBrut), int.Parse(CategorieImpozitare));
            convertToUSD = float.Parse(ConvertToUSDValue);
            float salariuNetInUSD = salariuNet / convertToUSD;
            return salariuNetInUSD;
        }

        public static void VerificaSalariuMediu()
        {
            if (ConvertToUSD(float.Parse(SalariuBrut), float.Parse(ConvertToUSDValue)) >= 2000)
            { 
                Console.WriteLine("Salariul este peste medie.");
            }
            else
            {
                Console.WriteLine("Salariul este sub medie.");
            }
        }
    }
}
