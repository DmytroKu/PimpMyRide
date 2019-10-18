using System;
using PimpMyRide.Domain;

namespace PimpMyRide.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Game started");
            var player = new Player(1000);
            var engine = new Engine(100, 0, 25, 52);
            var accumulator = new Accumulator(100, 0, 14, 4);
            var disks = new Disk[]
            {
                new Disk(100, 0, 10, 2),
                new Disk(100, 0, 15, 6),
                new Disk(100, 0, 15, 4),
                new Disk(100, 0, 16, 5),
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
                    var receipt = car.CanRepair;
                    if (receipt.repairable)
                    {

                        car.Repair();
                        Console.WriteLine("Repaired");
                        player.Money -= receipt.price;
                        Console.WriteLine($"Price:{receipt.price}\nBalance:{player.Money}");
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