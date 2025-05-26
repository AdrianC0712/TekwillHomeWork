using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2_Mutarea_Fișierelor_într_un_Director_Nou
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string projectDirectory = Directory.GetCurrentDirectory();

                projectDirectory = Path.GetFullPath(Path.Combine(projectDirectory, @"..\..\"));

                string sourceFolderPath = Path.Combine(projectDirectory, "SourceFolder");
                string backupFolderPath = Path.Combine(projectDirectory, "BackupFolder");

                if (!Directory.Exists(sourceFolderPath))
                {
                    Directory.CreateDirectory(sourceFolderPath);
                }

                string[] sampleFiles =
                {
                Path.Combine(sourceFolderPath, "file1.txt"),
                Path.Combine(sourceFolderPath, "file2.txt"),
                Path.Combine(sourceFolderPath, "file3.txt")
            };

                File.WriteAllText(sampleFiles[0], "Continut pentru file1.txt");
                File.WriteAllText(sampleFiles[1], "Continut pentru file2.txt");
                File.WriteAllText(sampleFiles[2], "Continut pentru file3.txt");

                Console.WriteLine("Fisiere create in SourceFolder:");
                foreach (string file in Directory.GetFiles(sourceFolderPath))
                {
                    Console.WriteLine(Path.GetFileName(file));
                }

                if (!Directory.Exists(backupFolderPath))
                {
                    Directory.CreateDirectory(backupFolderPath);
                }

                foreach (string file in Directory.GetFiles(sourceFolderPath))
                {
                    string fileName = Path.GetFileName(file);
                    string destinationPath = Path.Combine(backupFolderPath, fileName);
                    File.Move(file, destinationPath);
                }

                Console.WriteLine("\nFisiere mutate in BackupFolder:");
                if (Directory.GetFiles(backupFolderPath).Length == 0)
                {
                    Console.WriteLine("Niciun fisier nu a fost gasit in BackupFolder.");
                }
                else
                {
                    foreach (string file in Directory.GetFiles(backupFolderPath))
                    {
                        Console.WriteLine(Path.GetFileName(file));
                    }
                }

                if (Directory.GetFiles(sourceFolderPath).Length == 0)
                {
                    Console.WriteLine("\nToate fisierele au fost mutate cu succes din SourceFolder in BackupFolder.");
                }
                else
                {
                    Console.WriteLine("\nUnele fisiere nu au fost mutate din SourceFolder.");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Eroare la lucrul cu fisierele sau directoarele: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"A apărut o eroare: {ex.Message}");
            }
    }
    }
}
