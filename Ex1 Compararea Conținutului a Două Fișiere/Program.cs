using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex1_Compararea_Conținutului_a_Două_Fișiere
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file1Path = "file1.txt";
            string file2Path = "file2.txt";

            try
            {
                File.WriteAllText(file1Path, "Acesta este continutul primului fisier.\nLinie noua pentru test.");
                File.WriteAllText(file2Path, "Acesta este continutul celui de-al doilea fisier.\nLinie noua pentru test.");

                string content1 = File.ReadAllText(file1Path);
                string content2 = File.ReadAllText(file2Path);

                bool areIdentical = content1.Equals(content2, StringComparison.Ordinal);

                if (areIdentical)
                {
                    Console.WriteLine("Fisierele sunt identice.");
                }
                else
                {
                    Console.WriteLine("Fisierele nu sunt identice.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Eroare la lucrul cu fisierele: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"A aparut o eroare: {ex.Message}");
            }
        }
    }
}
