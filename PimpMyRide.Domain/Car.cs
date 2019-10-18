using System;

namespace PimpMyRide.Domain
{
    public class Car
    {
        private Engine Engine { get; }
        private Accumulator Accumulator { get; }
        private Disk[] Disks { get; }
        public int way { get; set; }

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

        public void Repair()
        {
            if(Engine.IsBroken) Engine.Repair();
            if(Accumulator.IsBroken) Accumulator.Repair();
            if(Disks[1].IsBroken) Disks[1].Repair();
            if(Disks[0].IsBroken) Disks[0].Repair();
            if(Disks[2].IsBroken) Disks[2].Repair();
            if(Disks[3].IsBroken) Disks[3].Repair();
        }
    }
}