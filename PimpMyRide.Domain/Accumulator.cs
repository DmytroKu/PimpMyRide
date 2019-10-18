namespace PimpMyRide.Domain
{
    public class Accumulator : Part
    {
        public Accumulator(int durability, decimal buyPrice, decimal repairPrice, int capacity) 
            : base(durability, buyPrice, repairPrice, capacity)
        {
        }
    }
}