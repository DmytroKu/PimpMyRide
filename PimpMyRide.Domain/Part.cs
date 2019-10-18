namespace PimpMyRide.Domain
{
   public abstract class Part
    {
        private int  Durability { get; }
        private decimal Price { get; }
        private bool IsBroken { get; }
        private int  Capacity { get; }

        protected Part(int durability, decimal price, bool isBroken, int capacity)
        {
            Durability = durability;
            Price = price;
            IsBroken = isBroken;
            Capacity = capacity;
        }
    }
}