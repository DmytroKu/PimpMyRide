namespace PimpMyRide.Domain
{
    public class Disk : Part
    {
        public Disk(int durability, decimal buyPrice, decimal repairPrice, int capacity) 
            : base(durability, buyPrice, repairPrice, capacity)
        {
        }
    }
}