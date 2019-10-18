namespace PimpMyRide.Domain
{
    public class Disks : Part
    {
        public Disks(int durability, decimal buyPrice, decimal repairPrice, bool isBroken, int capacity) 
            : base(durability, buyPrice, repairPrice, isBroken, capacity)
        {
        }
    }
}