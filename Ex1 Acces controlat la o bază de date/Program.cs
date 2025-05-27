using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex1_Acces_controlat_la_o_bază_de_date
{
    internal class Program
    {
        private static Semaphore semaphore = new Semaphore(3, 3);
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[3];

            for (int i = 0; i < threads.Length; i++)
            {
                int taskId = i + 1;
                threads[i] = new Thread(() => AccessDatabase(taskId));
                threads[i].Start();
            }

            foreach (Thread thread in threads)
            {
                thread.Join();
            }

            Console.WriteLine("Toate accesarile la baza de date s-au finalizat.");
        }

        static void AccessDatabase(int taskId)
        {
            Console.WriteLine($"Thread {taskId} asteapta să acceseze baza de date...");

            semaphore.WaitOne();

            try
            {
                Console.WriteLine($"Thread {taskId} a obtinut conexiunea la baza de date.");

                int workTime = new Random().Next(2000, 5000);
                Thread.Sleep(workTime);

                Console.WriteLine($"Thread {taskId} a finalizat operatiunea (a durat {workTime}ms).");
            }
            finally
            {
                semaphore.Release();
                Console.WriteLine($"Thread {taskId} a eliberat conexiunea.");
            }
        }
    }
}
