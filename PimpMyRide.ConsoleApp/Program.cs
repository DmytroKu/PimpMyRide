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
            var engine = new Engine(0, 0, false, 0);
            var accumulator = new Accumulator(0, 0, false, 0);
            var disks = new Disks[4];
            var car = new Car(engine, accumulator, disks);
            Console.WriteLine("Game over");

        }
    }
}