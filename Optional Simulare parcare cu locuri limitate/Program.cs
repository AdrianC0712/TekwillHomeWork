using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Optional_Simulare_parcare_cu_locuri_limitate
{
    internal class Program
    {
        private static Semaphore semaphore = new Semaphore(3, 3);
        static void Main(string[] args)
        {
            Thread[] cars = new Thread[6];
            for (int i = 0; i < cars.Length; i++)
            {
                int carId = i + 1;
                cars[i] = new Thread(() => ParkCar(carId));
                cars[i].Start();
            }
            foreach (Thread car in cars)
            {
                car.Join();
            }

            Console.WriteLine("Toate masinile au finalizat incercarile de parcare.");
        }
        static void ParkCar(int carId)
        {
            Console.WriteLine($"Masina {carId} asteapta sa intre in parcare...");
            semaphore.WaitOne();
            try
            {
                Console.WriteLine($"Masina {carId} a intrat in parcare.");
                int parkingTime = new Random().Next(2000, 5000);
                Thread.Sleep(parkingTime);
                Console.WriteLine($"Masina {carId} a parasit parcarea (a stat {parkingTime}ms).");
            }
            finally
            {
                semaphore.Release();
                Console.WriteLine($"Masina {carId} a eliberat locul de parcare.");
            }
        }
    }
}
