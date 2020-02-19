using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using PimpMyRide.Domain;

namespace PimpMyRide.ServerApp
{
    public class ServerGameService : GameService
    {
        private Queue<string> InfoQueue { get; }
        private int? Choice { get;  set; }

        public ServerGameService(IRepository repository) : base(repository)
        {
            InfoQueue = new Queue<string>();
        }


        protected override void InformGameOver()
        {
            InfoQueue.Enqueue("Game over");
            InfoQueue.Enqueue($"Final score is:{Car.Way}");
        }

        protected override void InformNothingToDo()
        {
            InfoQueue.Enqueue("Nothing to do");
        }

        protected override void InformCantMove()
        {
            InfoQueue.Enqueue("Can't move\nRepair your car");
        }

        protected override void InformMove()
        {
            InfoQueue.Enqueue("Move");
        }

        protected override int RequestChoice()
        {
            Choice = null;
            InfoQueue.Enqueue("1-Move");
            InfoQueue.Enqueue("2-End Game");
            InfoQueue.Enqueue("3x-Repair");
            InfoQueue.Enqueue("4x-Replace");

            while (!Choice.HasValue)
            {
                Thread.Sleep(1);
            }

            return Choice.Value;
        }

        protected override void InformMoneyIsOver()
        {
            InfoQueue.Enqueue("Money is over");
        }

        protected override void InformBalance()
        {
            InfoQueue.Enqueue($"Your balance is:{Player.Money}");
        }

        protected override void InformGameStarted()
        {
            InfoQueue.Enqueue("Game started");
        }


        protected override void InformNotReplacedBecauseOfBalance()
        {
            InfoQueue.Enqueue("Not enough money for replace");
        }

        protected override void InformReplace()
        {
            InfoQueue.Enqueue("Replaced");
        }


        protected override void InformUnrepairable()
        {
            InfoQueue.Enqueue("Cannot repair");
        }

        protected override void InformNotRepairedBecauseOfBalance()
        {
            InfoQueue.Enqueue("Not enough money for repair");
        }

        protected override void InformRepaired()
        {
            InfoQueue.Enqueue("Repaired");
        }

        protected override void ShowState()
        {
            InfoQueue.Enqueue("State of Car");
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
            InfoQueue.Enqueue(
                $"Durability: {part.Durability}; Capacity: {part.Capacity} ; IsBroken:{part.IsBroken};" +
                $" RepairCost: {part.RepairPrice}; ReplaceCost: {part.BuyPrice}");
        }

        public void SaveChoice(int choice)
        {
            Choice = choice;
        }

        public string[] GetInfo()
        {
            List<string> list = new List<string>();

            while (InfoQueue.Any())
            {
                list.Add(InfoQueue.Dequeue());
            }
            return list.ToArray();

        }
    }
}