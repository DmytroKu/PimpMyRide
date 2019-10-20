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
                        Console.WriteLine($"Engine durability and capacity:({engine.GetDurability}; {engine.GetCapacily})");
                        Console.WriteLine($"Accumulator durability and capacity:({accumulator.GetDurability}; {accumulator.GetCapacily})");
                        Console.WriteLine($"Left front disk  durability and capacity:({disks[0].GetDurability}; {disks[0].GetCapacily})");
                        Console.WriteLine($"Right front disk durability and capacity:({disks[1].GetDurability}; {disks[1].GetCapacily})");
                        Console.WriteLine($"Left rear disk durability and capacity:({disks[2].GetDurability}; {disks[2].GetCapacily})");
                        Console.WriteLine($"Right rear disk durability and capacity:({disks[3].GetDurability}; {disks[3].GetCapacily})");
                        Console.WriteLine($"Repair cost={receipt.price}\nReplaceCost={car.ReplaceCost}");
                    }
                }

                else if (choice == 2)
                {
                    if (receipt.repairable&&receipt.Durability!=100)
                    {
                        car.Repair();
                        Console.WriteLine("Repaired");
                        player.Money -= receipt.price;
                    }
                    else if (receipt.Durability==100) Console.WriteLine("You dont need to repair detail");
                    else Console.WriteLine("Cannot repair");
                }
                else if (choice == 3)
                {
                    if (car.ReplaceCost < player.Money&&!car.CanMove())
                    {
                        car.Replace();
                        player.Money -= car.ReplaceCost;
                        Console.WriteLine("Replaced");
                    }
                    else if(car.CanMove()) Console.WriteLine("You dont need to replace detail");
                    else  Console.WriteLine("Cannot replace");
                }
                else if (choice == 4) break;
                else Console.WriteLine("Try Again");
            } while ((!car.CanMove() && player.Money <= 0) ||choice!=4);

            Console.WriteLine("Game over");
            Console.Read();
        }
    }
}
