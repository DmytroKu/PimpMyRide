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
            var engine = new Engine(0, 0,0, false, 0);
            var accumulator = new Accumulator(0,0, 0, false, 0);
            var disks = new Disks[]
            {
                new Disks(100,0,0,false,0), 
                new Disks(100,0,0,false,0), 
                new Disks(100,0,0,false,0), 
                new Disks(100,0,0,false,0), 
            };

            var car = new Car(engine, accumulator, disks);
            for (int i = 0; i < 10; i++)
            {
                car.Move();
            }
            Console.WriteLine("Game over");

        }
    }
}