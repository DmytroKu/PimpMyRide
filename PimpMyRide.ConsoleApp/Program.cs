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
            var engine = new Engine(100, 0, 0, 0);
            var accumulator = new Accumulator(100, 0, 0, 0);
            var disks = new Disk[]
            {
                new Disk(100, 0, 0, 0),
                new Disk(100, 0, 0, 0),
                new Disk(100, 0, 0, 0),
                new Disk(100, 0, 0, 0),
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
                    break;
                }
            }

            Console.WriteLine("Game over");
        }
    }
}