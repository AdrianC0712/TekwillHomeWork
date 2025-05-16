using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilizare_array_bidimensional
{
    internal class Program
    {
        public static int[,] TablaSah = new int[8,8];
        static void Main(string[] args)
        {
            
            CompletareMatriceTabaSah(TablaSah);
            AfisareaMatriceTablaSah(TablaSah);

        }

        static void CompletareMatriceTabaSah(int[,] matrice)
        {
            for (int i = 0; i < 8; i++)
            { 
                for(int j = 0; j < 8; j++)
                {
                    matrice[i,j] = (i+j)%2 == 0 ? 1 : 0;
                }
            }
            TablaSah = matrice;
        }

        static void AfisareaMatriceTablaSah(int[,] matrice)
        {
            for (int i = 0; i < matrice.GetLength(0); i++)
            {
                for (int j = 0; j < matrice.GetLength(1); j++)
                {
                    Console.Write(matrice[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
