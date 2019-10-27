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
            var car = LoadCar() ?? CreateCar();
            while (true)
            {
                Console.WriteLine($"Your balance is:{player.Money}");

                if (player.Money <= 0)
                {
                    Console.WriteLine("Money is over");
                    break;
                }

                Console.WriteLine("1-Move");
                Console.WriteLine("2-End Game");
                Console.WriteLine("3x-Repair");
                Console.WriteLine("4x-Replace");
                ShowState(car);
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid number");
                    Console.WriteLine("Try again");
                }


                if (choice == 1)
                {
                    if (car.CanMove)
                    {
                        Console.WriteLine("Move");
                        player.Money += car.Move();
                    }
                    else
                    {
                        Console.WriteLine("Can't move\nRepair your car");
                    }
                }
                else if (choice == 2) break;
                else if (choice == 31)
                {
                    RepairPart(car.Engine, player);
                }
                else if (choice == 32)
                {
                    RepairPart(car.Accumulator, player);
                }
                else if (choice == 33)
                {
                    RepairPart(car.Disks[0], player);
                }
                else if (choice == 34)
                {
                    RepairPart(car.Disks[1], player);
                }
                else if (choice == 35)
                {
                    RepairPart(car.Disks[2], player);
                }
                else if (choice == 36)
                {
                    RepairPart(car.Disks[3], player);
                }

                else if (choice == 41)
                {
                    ReplacePart(car.Engine, player);
                }
                else if (choice == 42)
                {
                    ReplacePart(car.Accumulator, player);
                }
                else if (choice == 44)
                {
                    ReplacePart(car.Disks[0], player);
                }
                else if (choice == 44)
                {
                    ReplacePart(car.Disks[1], player);
                }
                else if (choice == 45)
                {
                    ReplacePart(car.Disks[2], player);
                }
                else if (choice == 46)
                {
                    ReplacePart(car.Disks[3], player);
                }
                else Console.WriteLine("Nothing to do");

                SaveCar(car);
            }

            Console.WriteLine("Game over");
            Console.WriteLine($"Final score is:{car.Way}");
            Console.Read();
        }

        private static Car? LoadCar()
        {
            return null;
        }

        private static void SaveCar(Car car)
        {
        }

        private static Car CreateCar()
        {
            var engine = new Engine(100, 150, 40, 25);
            var accumulator = new Accumulator(70, 80, 25, 20);
            var disks = new Disk[]
            {
                new Disk(50, 45, 15, 30),
                new Disk(40, 45, 15, 30),
                new Disk(30, 45, 15, 30),
                new Disk(10, 45, 15, 30),
            };
            var car = new Car(engine, accumulator, disks);
            return car;
        }

        private static void ReplacePart(Part part, Player player)
        {
            if (part.BuyPrice < player.Money)
            {
                player.Money -= part.BuyPrice;
                part.Replace();
                Console.WriteLine("Replaced");
            }
            else Console.WriteLine("Not enough money for replace");
        }

        private static void RepairPart(Part part, Player player)
        {
            if (part.Repairable)
            {
                if (player.Money >= part.RepairPrice)
                {
                    player.Money -= part.RepairPrice;
                    part.Repair();
                    Console.WriteLine("Repaired");
                }
                else Console.WriteLine("Not enough money for repair");
            }
            else Console.WriteLine("Cannot repair");
        }

        private static void ShowState(Car car)
        {
            Console.WriteLine("State of car");
            Console.Write("1.[Engine] ");
            ShowInfo(car.Engine);
            Console.Write("2.[Accumulator] ");
            ShowInfo(car.Accumulator);
            Console.Write("3.[Left front disk] ");
            ShowInfo(car.Disks[0]);
            Console.Write("4.[Right front disk] ");
            ShowInfo(car.Disks[1]);
            Console.Write("5.[Left rear disk] ");
            ShowInfo(car.Disks[2]);
            Console.Write("6.[Right rear disk] ");
            ShowInfo(car.Disks[3]);
        }

        private static void ShowInfo(Part part)
        {
            Console.WriteLine($"Durability: {part.Durability}; Capacity: {part.Capacity} ; IsBroken:{part.IsBroken};" +
                              $" RepairCost: {part.RepairPrice}; ReplaceCost: {part.BuyPrice}");
        }
    }
}