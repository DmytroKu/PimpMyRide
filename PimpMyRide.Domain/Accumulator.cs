namespace PimpMyRide.Domain
{
    public class Accumulator : Part
    {
        public Accumulator(int durability, decimal price, bool isBroken, int capacity) 
            : base(durability, price, isBroken, capacity)
        {
        }
    }
}