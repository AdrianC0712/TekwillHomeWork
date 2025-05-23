using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteElev
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduceti numarul de note a studentului: ");
            int n = int.Parse(Console.ReadLine());

            int[] note = new int[n];

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"Introduceti nota {i + 1}: ");
                note[i] = int.Parse(Console.ReadLine());
            }

            int notePozitive = 0;
            int noteNegative = 0;

            int sumaNotePozitive = 0;

            for (int i = 0; i < n; i++)
            {
                if (note[i] >= 5)
                {
                    notePozitive++;
                    sumaNotePozitive += note[i];
                }
                else
                {
                    noteNegative++;
                }
            }

            Console.WriteLine($"Numarul de note pozitive este: {notePozitive}");
            if (noteNegative > 0)
            {
                Console.WriteLine($"Numarul de note negative este: {noteNegative}, respectiv esti coregent!");
            }
            Console.WriteLine($"Media notelor pozitive este: {sumaNotePozitive / notePozitive}");
        }
    }
}
