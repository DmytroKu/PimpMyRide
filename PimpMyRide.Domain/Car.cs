using System;

namespace PimpMyRide.Domain
{
    public class Car
    {
        private Engine Engine { get; }
        private Accumulator Accumulator { get; }
        private Disks[] Disks { get; }

        public Car(Engine engine, Accumulator accumulator, Disks[] disks)
        {
            Engine = engine ?? throw new ArgumentNullException(nameof(engine));
            Accumulator = accumulator ?? throw new ArgumentNullException(nameof(accumulator));
            Disks = disks ?? throw new ArgumentNullException(nameof(disks));
        }
    }
}