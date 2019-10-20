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
            var engine = new Engine(100, 150, 40, 25);
            var accumulator = new Accumulator(70, 80, 25, 20);
            var disks = new Disk[]
            {
                new Disk(50, 45, 15, 30),
                new Disk(40, 45, 15, 30),
                new Disk(30, 45, 15, 30),
                new Disk(10, 45, 15, 30),
            };
            int choice;
            var car = new Car(engine, accumulator, disks);
            do
            {
               
                if (player.Money <= 0)
                {
                    Console.WriteLine("Money is over");
                    break;
                }
                Console.WriteLine("1-Move");
                Console.WriteLine("2-Repair");
                Console.WriteLine("3-Replace");
                Console.WriteLine("4-End game");
                Console.WriteLine($"Your balance is:{player.Money}");
               

                while (!int.TryParse(Console.ReadLine(),out choice))
                {
                    Console.WriteLine("Invalid number");
                    Console.WriteLine("Try again");
                }
                var receipt = car.CanRepair;
                if (choice == 1)
                {
                    if (car.CanMove())
                    {
                        Console.WriteLine("Move");
                        player.Money += car.Move();
                    }
                    else
                    {
                        Console.WriteLine("Can't move\nRepair your car");
                        Console.WriteLine("State of car");
                        Console.WriteLine($"Engine durability and capacity:({car.Engine.Durability}; {car.Engine.Capacity})");
                        Console.WriteLine($"Accumulator durability and capacity:({car.Accumulator.Durability}; {car.Accumulator.Capacity})");
                        Console.WriteLine($"Left front disk  durability and capacity:({car.Disks[0].Durability}; {car.Disks[0].Capacity})");
                        Console.WriteLine($"Right front disk durability and capacity:({car.Disks[1].Durability}; {car.Disks[1].Capacity})");
                        Console.WriteLine($"Left rear disk durability and capacity:({car.Disks[2].Durability}; {car.Disks[2].Capacity})");
                        Console.WriteLine($"Right rear disk durability and capacity:({car.Disks[3].Durability}; {car.Disks[3].Capacity})");
                        Console.WriteLine($"Repair cost={receipt.repairPrice}\nReplaceCost={car.ReplaceCost}");
                    }
                }

                else if (choice == 2)
                {
                        if (receipt.repairable)
                        {
                            if (player.Money >= receipt.repairPrice)
                            {
                                player.Money -= receipt.repairPrice;
                                car.Repair();
                                Console.WriteLine("Repaired");
                            }
                            else Console.WriteLine("Not enough money for repair");

                        }
                        else Console.WriteLine("Cannot repair");
                }
                else if (choice == 3)
                {
                        if (car.ReplaceCost < player.Money)
                        {
                            player.Money -= car.ReplaceCost;
                            car.Replace();
                            Console.WriteLine("Replaced");
                        }
                        else Console.WriteLine("Not enough money for replace");
                }
                else if (choice == 4) break;
                else Console.WriteLine("Try Again");
            } while (choice!=4);

            Console.WriteLine("Game over");
            Console.Read();
        }
    }
}
