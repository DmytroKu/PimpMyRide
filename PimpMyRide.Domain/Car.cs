using System;

namespace PimpMyRide.Domain
{
    public class Car
    {
        private Engine Engine { get; }
        private Accumulator Accumulator { get; }
        private Disks[] Disks { get; }
        public int  way { get; set; }

        public Car(Engine engine, Accumulator accumulator, Disks[] disks)
        {
            if (disks == null) throw new ArgumentNullException(nameof(disks));
            if (disks.Length !=4) throw new ArgumentException("Car should contain 4 disks", nameof(disks));
            foreach (var disk in disks)
                if (disk == null)
                    throw new ArgumentNullException(nameof(disk), "One of disk is null");
            Engine = engine ?? throw new ArgumentNullException(nameof(engine));
            Accumulator = accumulator ?? throw new ArgumentNullException(nameof(accumulator));
            Disks = disks;
        }

        public void  Move()
        {
            way += 10;
            Engine.decreaseDurability();
            Accumulator.decreaseDurability();
            foreach (var disks in Disks)
            {
                disks.decreaseDurability();
            }
            
        }

        public bool CanMove()
        {
            return true;
        }
    }
}