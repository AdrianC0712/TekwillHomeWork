using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex3.OPTIONAL_Gestionarea_unui_inventar_de_produse
{
    internal class Program
    {
        public class DateInvalideException : Exception
        {
            public DateInvalideException(string message) : base(message)
            {
            }
        }

        public class ProdusInexistentException : Exception
        {
            public ProdusInexistentException(string message) : base(message)
            {
            }
        }

        public class Produs
        {
            public string Nume { get; set; }
            public int Cantitate { get; set; }
            public double PretUnitate { get; set; }

            public Produs(string nume, int cantitate, double pretUnitate)
            {
                Nume = nume;
                Cantitate = cantitate;
                PretUnitate = pretUnitate;
            }

            public double ValoareTotala()
            {
                return Cantitate * PretUnitate;
            }

            public override string ToString()
            {
                return $"Produs: {Nume}, Cantitate: {Cantitate}, Pret unitate: {PretUnitate:F2} MDL, Valoare totala: {ValoareTotala():F2} MDL";
            }
        }
        static void Main(string[] args)
        {
            List<Produs> inventar = new List<Produs>();

            try
            {
                Console.Write("Introduceti numarul de produse: ");
                if (!int.TryParse(Console.ReadLine(), out int numarProduse) || numarProduse <= 0)
                {
                    throw new DateInvalideException("Numarul de produse trebuie sa fie un numar intreg pozitiv.");
                }

                for (int i = 0; i < numarProduse; i++)
                {
                    Console.WriteLine($"\nIntroduceti detaliile pentru produsul {i + 1}:");

                    Console.Write("Nume produs: ");
                    string nume = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(nume))
                    {
                        throw new DateInvalideException("Numele produsului nu poate fi gol.");
                    }

                    Console.Write("Cantitate: ");
                    if (!int.TryParse(Console.ReadLine(), out int cantitate) || cantitate <= 0)
                    {
                        throw new DateInvalideException("Cantitatea trebuie sa fie un numar intreg pozitiv.");
                    }

                    Console.Write("Pret unitate (MDL): ");
                    if (!double.TryParse(Console.ReadLine(), out double pretUnitate) || pretUnitate <= 0)
                    {
                        throw new DateInvalideException("Pretul unitate trebuie sa fie un numar real pozitiv.");
                    }

                    inventar.Add(new Produs(nume, cantitate, pretUnitate));
                }

                double valoareTotalaStoc = 0;
                Console.WriteLine("\nInventar produse:");
                foreach (var produs in inventar)
                {
                    Console.WriteLine(produs.ToString());
                    valoareTotalaStoc += produs.ValoareTotala();
                }
                Console.WriteLine($"\nValoare totala stoc: {valoareTotalaStoc:F2} MDL");

                Console.Write("\nIntroduceti numele produsului pentru cautare: ");
                string numeCautat = Console.ReadLine();
                bool gasit = false;

                foreach (var produs in inventar)
                {
                    if (produs.Nume.Equals(numeCautat, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine($"\nProdus gasit: {produs.ToString()}");
                        gasit = true;
                        break;
                    }
                }

                if (!gasit)
                {
                    throw new ProdusInexistentException($"Produsul '{numeCautat}' nu exista in inventar.");
                }
            }
            catch (DateInvalideException ex)
            {
                Console.WriteLine($"Eroare la introducerea datelor: {ex.Message}");
            }
            catch (ProdusInexistentException ex)
            {
                Console.WriteLine($"Eroare la cautare: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"A aparut o eroare neasteptata: {ex.Message}");
            }
        }
    }
}
