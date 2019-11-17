using PimpMyRide.Domain;

namespace PimpMyRide.WindowsFormsApp
{
    public class WindowsFormsGame:Game
    {
        private PimpMyRideForm Form { get; }

        public WindowsFormsGame(PimpMyRideForm form)
        {
            Form = form;
        }
        protected override void ShowState()
        {
            throw new System.NotImplementedException();
        }

        protected override void InformGameStarted()
        {
            throw new System.NotImplementedException();
        }

        protected override void InformBalance()
        {
            throw new System.NotImplementedException();
        }

        protected override void InformMoneyIsOver()
        {
            throw new System.NotImplementedException();
        }

        protected override int RequestChoice()
        {
            throw new System.NotImplementedException();
        }

        protected override void InformMove()
        {
            throw new System.NotImplementedException();
        }

        protected override void InformCantMove()
        {
            throw new System.NotImplementedException();
        }

        protected override void InformNothingToDo()
        {
            throw new System.NotImplementedException();
        }

        protected override void InformGameOver()
        {
            throw new System.NotImplementedException();
        }

        protected override void InformNotReplacedBecauseOfBalance()
        {
            throw new System.NotImplementedException();
        }

        protected override void InformReplace()
        {
            throw new System.NotImplementedException();
        }

        protected override void InformUnrepairable()
        {
            throw new System.NotImplementedException();
        }

        protected override void InformNotRepairedBecauseOfBalance()
        {
            throw new System.NotImplementedException();
        }

        protected override void InformRepaired()
        {
            throw new System.NotImplementedException();
        }
    }
}