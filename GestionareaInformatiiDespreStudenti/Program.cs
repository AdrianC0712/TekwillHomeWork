using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GestionareaInformatiiDespreStudenti
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            string input;

            Console.WriteLine("Introduceti numele studentului:");
            input = Console.ReadLine();
            student.nume = input;
            Console.WriteLine("Introduceti varsta studentului:");
            input = Console.ReadLine();
            student.varsta = int.Parse(input);
            Console.WriteLine("Introduceti specializarea studentului:");
            input = Console.ReadLine();
            student.specializare = input;
            Console.WriteLine("Introduceti anul de studii al studentului:");
            input = Console.ReadLine();
            if (Enum.TryParse(input, out AnulDeStudii anulDeStudii))
            {
                student.anulDeStudii = anulDeStudii.ToString();
            }
            else
            {
                Console.WriteLine("Anul de studii introdus nu este valid.");
                return;
            }

            Console.WriteLine($"Informatia studentului este:\n Nume:{student.nume};\n Virsta:{student.varsta};\n Specializare:{student.specializare};\n Anul de studii: {student.anulDeStudii}");
        }

        struct Student
        {
            public string nume;
            public int varsta;
            public string specializare;
            public string anulDeStudii;
        }

        enum AnulDeStudii
        { 
            I,
            II,
            III,
            IV,
            V,
            VI,
            VII,
            VIII
        }
    }
}
