using System;

namespace PimpMyRide.Domain
{
    public class Car
    {
        public Engine Engine { get; }
        public Accumulator Accumulator { get; }
        public Disk[] Disks { get; }
        public int Way { get; private set; }


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

        public bool CanMove =>
            !Engine.IsBroken
            && !Accumulator.IsBroken
            && !Disks[1].IsBroken
            && !Disks[0].IsBroken
            && !Disks[2].IsBroken
            && !Disks[3].IsBroken;
    }
}