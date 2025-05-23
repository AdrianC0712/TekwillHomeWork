using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SumaCifreiWhile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti un numar: ");
            int n = int.Parse(Console.ReadLine());
            int suma = 0;
            while (n > 0)
            {
                suma += n % 10;
                n /= 10;
            }
            Console.WriteLine($"Suma cifrelor este: {suma}");
        }
    }
}
