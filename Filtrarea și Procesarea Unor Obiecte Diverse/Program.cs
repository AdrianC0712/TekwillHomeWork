using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filtrarea_și_Procesarea_Unor_Obiecte_Diverse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Cunoasteti tipul obiectului pe care doriti sa-l introuceti?");
            Console.WriteLine("1. Da, cunosc tipul de date.");
            Console.WriteLine("2. Nu, nu cunosc tipul de date.");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    SelectOption();
                    break;
                case "2":
                    InsertObject();
                    break;
                default:
                    Console.WriteLine("Optiune invalida.");
                    break;
            }
        }

        #region Cand selectam tipul de date care il introducem
        static void SelectOption()
        {
            Console.WriteLine("Alegeti o optiune:");
            Console.WriteLine("1. Introduceti un numar");
            Console.WriteLine("2. Introduceti un sir de caractere");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    InsertNumber();
                    break;
                case "2":
                    InsertString();
                    break;
                default:
                    Console.WriteLine("Optiune invalida.");
                    break;
            }
        }
        static void InsertNumber()
        {
            Console.WriteLine("Introduceti un numar:");
            int numar = int.Parse(Console.ReadLine());
            CheckParImparNumber(numar);
        }
        static void InsertString()
        {
            Console.WriteLine("Introduceti un sir de caractere:");
            string sir = Console.ReadLine();
            CheckString(sir);
        }

        static void CheckParImparNumber(int numar)
        {
            if (numar % 2 == 0)
            {
                Console.WriteLine("Numarul este par.");
            }
            else
            {
                Console.WriteLine("Numarul este impar.");
            }
        }

        static void CheckString(string sir)
        {
            if (sir.Length >= 5)
            {
                Console.WriteLine("Sirul este mare.");
            }
            else
            {
                Console.WriteLine("Sirul este mic.");
            }
        }
        #endregion

        #region Cand nu cunoastem tipul de date care il introducem

        static void PorcesareObiect(object item)
        {
            switch (item)
            {
                case int number:
                    Console.WriteLine(number % 2 == 0
                    ? $"Număr par: {number}"
                    : $"Număr impar: {number}");
                    break;
                case string text:
                    Console.WriteLine(text.Length >= 5
                    ? $"Text lung: {text}"
                    : $"Text scurt: {text}");
                    break;
                default:
                    Console.WriteLine($"Tip de date necunoscut: {item.GetType()}");
                break;
            }
        }

        static void InsertObject()
        { 
            Console.WriteLine("Introduceti un obiect (numar sau sir de caractere):");
            string input = Console.ReadLine();

            PorcesareObiect(input);
        }
        #endregion
    }
}

