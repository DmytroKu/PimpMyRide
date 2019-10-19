using System;

namespace PimpMyRide.Domain
{
    public class Car
    {
        private Engine Engine { get; }
        private Accumulator Accumulator { get; }
        private Disk[] Disks { get; }
        private int way { get; set; }

        public Car(Engine engine, Accumulator accumulator, Disk[] disks)
        {
            if (disks == null) throw new ArgumentNullException(nameof(disks));
            if (disks.Length != 4) throw new ArgumentException("Car should contain 4 disks", nameof(disks));
            foreach (var disk in disks)
                if (disk == null)
                    throw new ArgumentNullException(nameof(disk), "One of disk is null");
            Engine = engine ?? throw new ArgumentNullException(nameof(engine));
            Accumulator = accumulator ?? throw new ArgumentNullException(nameof(accumulator));
            Disks = disks;
        }

        public void Move()
        {
            way += 10;
            Engine.DecreaseDurability();
            Accumulator.DecreaseDurability();
            foreach (var disks in Disks)
            {
                disks.DecreaseDurability();
            }
        }

        public bool CanMove() =>
            !Engine.IsBroken
            && !Accumulator.IsBroken
            && !Disks[1].IsBroken
            && !Disks[0].IsBroken
            && !Disks[2].IsBroken
            && !Disks[3].IsBroken;

        public decimal Replace()
        {
            if (Engine.IsBroken)
            {
                return Engine.Replace();
            }

            if (Accumulator.IsBroken)
            {
                return Accumulator.Replace();
            }

            if (Disks[1].IsBroken)
            {
                return Disks[1].Replace();
            }

            if (Disks[0].IsBroken)
            {
                return Disks[0].Replace();
            }

            if (Disks[2].IsBroken)
            {
               return  Disks[2].Replace();
            }

            if (Disks[3].IsBroken)
            {
               return Disks[3].Replace();
            }

            return 0;
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

        public (bool repairable, decimal price) CanRepair
        {
            get
            {
                if (Engine.CanRepair.repairable) return Engine.CanRepair;
                if (Accumulator.CanRepair.repairable) return Accumulator.CanRepair;
                if (Disks[0].CanRepair.repairable) return Disks[0].CanRepair;
                if (Disks[1].CanRepair.repairable) return Disks[1].CanRepair;
                if (Disks[2].CanRepair.repairable) return Disks[2].CanRepair;
                if (Disks[3].CanRepair.repairable) return Disks[3].CanRepair;
                return (false, 0);
            }
        }
    }
}