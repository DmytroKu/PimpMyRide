using System;

namespace PimpMyRide.Domain
{
    public class Car
    {
        private Engine Engine { get; }
        private Accumulator Accumulator { get; }
        private Disk[] Disks { get; }
        private int Way { get; set; }


        public Car(Engine engine, Accumulator accumulator, Disk[] disks)
        {
            if (disks.Length != 4) throw new ArgumentException("Car should contain 4 disks", nameof(disks));
            Engine = engine;
            Accumulator = accumulator;
            Disks = disks;
        }

        public decimal Move()
        {
            Way += 1;
            Engine.DecreaseDurability();
            Accumulator.DecreaseDurability();
            foreach (var disks in Disks)
            {
                disks.DecreaseDurability();
            }

            return 5; //Your salary
        }

        public bool CanMove() =>
            !Engine.IsBroken
            && !Accumulator.IsBroken
            && !Disks[1].IsBroken
            && !Disks[0].IsBroken
            && !Disks[2].IsBroken
            && !Disks[3].IsBroken;

        public void Replace()
        {
            if (Engine.IsBroken)
            {
                Engine.Replace();
                return;
            }

            if (Accumulator.IsBroken)
            {
                Accumulator.Replace();
                return;
            }

            if (Disks[1].IsBroken)
            {
                Disks[1].Replace();
                return;
            }

            if (Disks[0].IsBroken)
            {
                Disks[0].Replace();
                return;
            }

            if (Disks[2].IsBroken)
            {
                Disks[2].Replace();
                return;
            }

            if (Disks[3].IsBroken)
            {
                Disks[3].Replace();
                return;
            }
        }

        public void Repair()
        {
            if (Engine.IsBroken)
            {
                Engine.Repair();
                return;
            }

            if (Accumulator.IsBroken)
            {
                Accumulator.Repair();
                return;
            }

            if (Disks[1].IsBroken)
            {
                Disks[1].Repair();
                return;
            }

            if (Disks[0].IsBroken)
            {
                Disks[0].Repair();
                return;
            }

            if (Disks[2].IsBroken)
            {
                Disks[2].Repair();
                return;
            }

            if (Disks[3].IsBroken)
            {
                Disks[3].Repair();
                return;
            }
        }

        public (bool repairable, decimal price, int Durability, int Capacity) CanRepair
        {
            get
            {
                if (Engine.CanRepair.repairable) return Engine.CanRepair;
                if (Accumulator.CanRepair.repairable) return Accumulator.CanRepair;
                if (Disks[0].CanRepair.repairable) return Disks[0].CanRepair;
                if (Disks[1].CanRepair.repairable) return Disks[1].CanRepair;
                if (Disks[2].CanRepair.repairable) return Disks[2].CanRepair;
                if (Disks[3].CanRepair.repairable) return Disks[3].CanRepair;
                return (false, 0, 0, 0);
            }
        }

        public decimal ReplaceCost
        {
            get
            {
                if (Engine.IsBroken) return Engine.ReplaceCost;
                if (Accumulator.IsBroken) return Accumulator.ReplaceCost;
                if (Disks[0].IsBroken) return Disks[0].ReplaceCost;
                if (Disks[1].IsBroken) return Disks[1].ReplaceCost;
                if (Disks[2].IsBroken) return Disks[2].ReplaceCost;
                if (Disks[3].IsBroken) return Disks[3].ReplaceCost;
                return 0;
            }
        }
    }
}