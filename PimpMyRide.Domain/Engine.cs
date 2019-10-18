namespace PimpMyRide.Domain
{
    public class Engine : Part
    {
        public Engine(int durability, decimal buyPrice, decimal repairPrice, bool isBroken, int capacity) 
            : base(durability, buyPrice, repairPrice, isBroken, capacity)
        {
        }
    }
}