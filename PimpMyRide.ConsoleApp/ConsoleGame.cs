using System;
using PimpMyRide.Domain;

namespace PimpMyRide.ConsoleApp
{
    public class ConsoleGame : Game
    {
        protected override void InformGameOver()
        {
            Console.WriteLine("Game over");
            Console.WriteLine($"Final score is:{Car.Way}");
        }

        protected override void InformNothingToDo()
        {
            Console.WriteLine("Nothing to do");
        }

        protected override void InformCantMove()
        {
            Console.WriteLine("Can't move\nRepair your car");
        }

        protected override void InformMove()
        {
            Console.WriteLine("Move");
        }

        protected override int RequestChoice()
        {
            Console.WriteLine("1-Move");
            Console.WriteLine("2-End Game");
            Console.WriteLine("3x-Repair");
            Console.WriteLine("4x-Replace");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid number");
                Console.WriteLine("Try again");
            }

            return choice;
        }

        protected override void InformMoneyIsOver()
        {
            Console.WriteLine("Money is over");
        }

        protected override void InformBalance()
        {
            Console.WriteLine($"Your balance is:{Player.Money}");
        }

        protected override void InformGameStarted()
        {
            Console.WriteLine("Game started");
        }


        protected override void InformNotReplacedBecauseOfBalance()
        {
            Console.WriteLine("Not enough money for replace");
        }

        protected override void InformReplace()
        {
            Console.WriteLine("Replaced");
        }


        protected override void InformUnrepairable()
        {
            Console.WriteLine("Cannot repair");
        }

        protected override void InformNotRepairedBecauseOfBalance()
        {
            Console.WriteLine("Not enough money for repair");
        }

        protected override void InformRepaired()
        {
            Console.WriteLine("Repaired");
        }

        protected override void ShowState()
        {
            Console.WriteLine("State of Car");
            Console.Write("1.[Engine] ");
            ShowInfo(Car.Engine);
            Console.Write("2.[Accumulator] ");
            ShowInfo(Car.Accumulator);
            Console.Write("3.[Left front disk] ");
            ShowInfo(Car.Disks[0]);
            Console.Write("4.[Right front disk] ");
            ShowInfo(Car.Disks[1]);
            Console.Write("5.[Left rear disk] ");
            ShowInfo(Car.Disks[2]);
            Console.Write("6.[Right rear disk] ");
            ShowInfo(Car.Disks[3]);
        }

        public void ShowInfo(Part part)
        {
            Console.WriteLine(
                $"Durability: {part.Durability}; Capacity: {part.Capacity} ; IsBroken:{part.IsBroken};" +
                $" RepairCost: {part.RepairPrice}; ReplaceCost: {part.BuyPrice}");
        }
    }
}