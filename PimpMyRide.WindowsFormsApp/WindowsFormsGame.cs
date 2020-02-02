using PimpMyRide.Domain;
using PimpMyRide.Domain.FileStorage;
using System.Threading;

namespace PimpMyRide.WindowsFormsApp
{
    public class WindowsFormsGameService : GameService
    {
        private PimpMyRideForm Form { get; }

        public WindowsFormsGameService(PimpMyRideForm form) : base(new FileRepository())
        {
            Form = form;
        }

        protected override void InformGameOver()
        {
            Form.AppendLine("Game over");
            Form.AppendLine($"Final score is:{Car.Way}");
        }

        protected override void InformNothingToDo()
        {
            Form.AppendLine("Nothing to do");
        }

        protected override void InformCantMove()
        {
            Form.AppendLine("Can't move\nRepair your car");
        }

        protected override void InformMove()
        {
            Form.AppendLine("Move");
        }

        protected override int RequestChoice()
        {
            Form.AppendLine("1-Move");
            Form.AppendLine("2-End Game");
            Form.AppendLine("3x-Repair");

            Form.AppendLine("4x-Replace");
            Form.RequestInput();
            while (!Form.choice.HasValue)
            {
                Thread.Sleep(1);
            }

            return Form.choice.Value;
        }

        protected override void InformMoneyIsOver()
        {
            Form.AppendLine("Money is over");
        }

        protected override void InformBalance()
        {
            Form.AppendLine($"Your balance is:{Player.Money}");
        }

        protected override void InformGameStarted()
        {
            Form.AppendLine("Game started");
        }


        protected override void InformNotReplacedBecauseOfBalance()
        {
            Form.AppendLine("Not enough money for replace");
        }

        protected override void InformReplace()
        {
            Form.AppendLine("Replaced");
        }


        protected override void InformUnrepairable()
        {
            Form.AppendLine("Cannot repair");
        }

        protected override void InformNotRepairedBecauseOfBalance()
        {
            Form.AppendLine("Not enough money for repair");
        }

        protected override void InformRepaired()
        {
            Form.AppendLine("Repaired");
        }

        protected override void ShowState()
        {
            Form.AppendLine("State of Car");
            Form.Append("1.[Engine] ");
            ShowInfo(Car.Engine);
            Form.Append("2.[Accumulator] ");
            ShowInfo(Car.Accumulator);
            Form.Append("3.[Left front disk] ");
            ShowInfo(Car.Disks[0]);
            Form.Append("4.[Right front disk] ");
            ShowInfo(Car.Disks[1]);
            Form.Append("5.[Left rear disk] ");
            ShowInfo(Car.Disks[2]);
            Form.Append("6.[Right rear disk] ");
            ShowInfo(Car.Disks[3]);
        }

        public void ShowInfo(Part part)
        {
            Form.AppendLine(
                $"Durability: {part.Durability}; Capacity: {part.Capacity} ; IsBroken:{part.IsBroken};" +
                $" RepairCost: {part.RepairPrice}; ReplaceCost: {part.BuyPrice}");
        }
    }
}