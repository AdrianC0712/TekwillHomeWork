using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestionare_a_meniului
{
    internal class Program
    {
        public enum MenuOption
        {
            Supa = 1,
            SalataCaesar,
            SalataGreceasca,
            Inghetata
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Meniu disponibil:");
            Console.WriteLine("1 - Supă");
            Console.WriteLine("2 - Salata Caesar");
            Console.WriteLine("3 - Salata Grecească");
            Console.WriteLine("4 - Înghețată");
            Console.Write("Introduceți numărul opțiunii dorite: ");

            if (int.TryParse(Console.ReadLine(), out int option))
            {
                MenuOption selectedOption;
                if (Enum.IsDefined(typeof(MenuOption), option))
                {
                    selectedOption = (MenuOption)option;
                    switch (selectedOption)
                    {
                        case MenuOption.Supa:
                            Console.WriteLine("Supă: Supă cremă de legume, proaspăt preparată. Preț: 120 Lei");
                            break;
                        case MenuOption.SalataCaesar:
                            Console.WriteLine("Salata Caesar: Salată cu pui, crutoane și dressing Caesar. Preț: 200 Lei");
                            break;
                        case MenuOption.SalataGreceasca:
                            Console.WriteLine("Salata Grecească: Roșii, castraveți, ceapă, măsline și brânză feta. Preț: 180 Lei");
                            break;
                        case MenuOption.Inghetata:
                            Console.WriteLine("Înghețată: Înghețată de vanilie și ciocolată cu topping de fructe. Preț: 100 Lei");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Eroare: Opțiunea introdusă nu este validă!");
                }
            }
            else
            {
                Console.WriteLine("Eroare: Vă rugăm să introduceți un număr valid!");
            }
        }
    }
}
