namespace PimpMyRide.Domain
{
    public class Disks : Part
    {
        public Disks(int durability, decimal price, bool isBroken, int capacity) 
            : base(durability, price, isBroken, capacity)
        {

        }
    }
}