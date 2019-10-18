using System;
using PimpMyRide.Domain;

namespace PimpMyRide.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Game started");
            var player = new Player(0);
            var engine = new Engine(100, 0, 0, 52);
            var accumulator = new Accumulator(100, 0, 0, 4);
            var disks = new Disk[]
            {
                new Disk(100, 0, 0, 2),
                new Disk(100, 0, 0, 6),
                new Disk(100, 0, 0, 4),
                new Disk(100, 0, 0, 5),
            };

            var car = new Car(engine, accumulator, disks);
            for (int i = 0; i < 1010; i++)
            {
                if (car.CanMove())
                {
                    Console.WriteLine("Move");
                    car.Move();
                }
                else
                {
                    Console.WriteLine("Can't move");
                    if (car.CanRepair)
                    {
                        car.Repair();
                        Console.WriteLine("Repaired");
                    }
                    else
                    {
                        car.Replace();
                        Console.WriteLine("Replaced");
                    }
                }
            }

            Console.WriteLine("Game over");
            Console.Read();
        }
    }
}