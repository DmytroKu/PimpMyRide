namespace PimpMyRide.Domain
{
    public class Engine : Part
    {
        protected Engine(int durability, decimal price, bool isBroken, int capacity) 
            : base(durability, price, isBroken, capacity)
        {
        }
    }
}