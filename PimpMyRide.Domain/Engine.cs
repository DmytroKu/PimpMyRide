namespace PimpMyRide.Domain
{
    public class Engine : Part
    {
        public Engine(int durability, decimal price, bool isBroken, int capacity) 
            : base(durability, price, isBroken, capacity)
        {
        }
    }
}