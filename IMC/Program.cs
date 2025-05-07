using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMC
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti greutatea:");
            string inputGreutate = Console.ReadLine();
            Console.WriteLine("Introduceti inaltimea:");
            string inputInaltime = Console.ReadLine();
            float greutate = float.Parse(inputGreutate)/(float.Parse(inputInaltime)*float.Parse(inputInaltime));
            Console.WriteLine("IMC-ul este: " + greutate);
        }
    }
}
