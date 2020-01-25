namespace PimpMyRide.Domain
{
    public abstract class Game
    {
        protected Game(IRepository repository)
        {
            Player = new Player(1000);
            Repository = repository;
            Car = Repository.LoadCar() ?? CreateCar();
        }

        private IRepository Repository { get; }

        protected Car Car { get; }

        protected Player Player { get; }

        private static Car CreateCar()
        {
            var engine = new Engine(100, 150, 40, 25);
            var accumulator = new Accumulator(70, 80, 25, 20);
            var disks = new[]
            {
                new Disk(50, 45, 15, 30),
                new Disk(40, 45, 15, 30),
                new Disk(30, 45, 15, 30),
                new Disk(10, 45, 15, 30),
            };
            var car = new Car(engine, accumulator, disks);
            return car;
        }

        public void Run()
        {
            InformGameStarted();

            while (true)
            {
                InformBalance();

                if (Player.Money <= 0)
                {
                    InformMoneyIsOver();
                    break;
                }

                ShowState();
                var choice = RequestChoice();


                if (choice == 1)
                {
                    if (Car.CanMove)
                    {
                        InformMove();
                        Player.Money += Car.Move();
                    }
                    else
                    {
                        InformCantMove();
                    }
                }
                else if (choice == 2) break;
                else if (choice == 31)
                {
                    RepairPart(Car.Engine);
                }
                else if (choice == 32)
                {
                    RepairPart(Car.Accumulator);
                }
                else if (choice == 33)
                {
                    RepairPart(Car.Disks[0]);
                }
                else if (choice == 34)
                {
                    RepairPart(Car.Disks[1]);
                }
                else if (choice == 35)
                {
                    RepairPart(Car.Disks[2]);
                }
                else if (choice == 36)
                {
                    RepairPart(Car.Disks[3]);
                }

                else if (choice == 41)
                {
                    ReplacePart(Car.Engine);
                }
                else if (choice == 42)
                {
                    ReplacePart(Car.Accumulator);
                }
                else if (choice == 44)
                {
                    ReplacePart(Car.Disks[0]);
                }
                else if (choice == 44)
                {
                    ReplacePart(Car.Disks[1]);
                }
                else if (choice == 45)
                {
                    ReplacePart(Car.Disks[2]);
                }
                else if (choice == 46)
                {
                    ReplacePart(Car.Disks[3]);
                }
                else InformNothingToDo();

                Repository.SaveCar(Car);
            }

            InformGameOver();
        }

        private void RepairPart(Part part)
        {
            if (part.Repairable)
            {
                if (Player.Money >= part.RepairPrice)
                {
                    Player.Money -= part.RepairPrice;
                    part.Repair();
                    InformRepaired();
                }
                else InformNotRepairedBecauseOfBalance();
            }
            else InformUnrepairable();
        }

        private void ReplacePart(Part part)
        {
            if (part.BuyPrice < Player.Money)
            {
                Player.Money -= part.BuyPrice;
                part.Replace();
                InformReplace();
            }
            else InformNotReplacedBecauseOfBalance();
        }

        protected abstract void ShowState();
        protected abstract void InformGameStarted();
        protected abstract void InformBalance();
        protected abstract void InformMoneyIsOver();
        protected abstract int RequestChoice();
        protected abstract void InformMove();
        protected abstract void InformCantMove();
        protected abstract void InformNothingToDo();
        protected abstract void InformGameOver();
        protected abstract void InformNotReplacedBecauseOfBalance();
        protected abstract void InformReplace();
        protected abstract void InformUnrepairable();
        protected abstract void InformNotRepairedBecauseOfBalance();
        protected abstract void InformRepaired();
    }
}