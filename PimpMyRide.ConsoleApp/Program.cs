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
            var engine = new Engine(100, 150, 25, 25);
            var accumulator = new Accumulator(100, 80, 14, 20);
            var disks = new Disk[]
            {
                new Disk(100, 45, 15, 30),
                new Disk(100, 0, 15, 30),
                new Disk(100, 0, 15, 30),
                new Disk(100, 0, 15, 30),
            };

            var car = new Car(engine, accumulator, disks);
            for (int i = 0; i < 101; i++)
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
                    var ReplaceCost=
                    if (receipt.repairable)
                    {

                        car.Repair();
                        Console.WriteLine("Repaired");
                        player.Money -= receipt.price;
                        Console.WriteLine($"Price:{receipt.price}\nBalance:{player.Money}");
                    }
                    else if(player.Money>)
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