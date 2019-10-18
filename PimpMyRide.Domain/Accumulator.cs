namespace PimpMyRide.Domain
{
    public class Accumulator : Part
    {
        public Accumulator(int durability, decimal buyPrice, decimal repairPrice, bool isBroken, int capacity) 
            : base(durability, buyPrice, repairPrice, isBroken, capacity)
        {
        }
    }
}