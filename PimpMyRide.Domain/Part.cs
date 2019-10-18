namespace PimpMyRide.Domain
{
   public abstract class Part
    {
        private int  Durability { get; set; }
        private decimal BuyPrice { get; }
        private decimal RepairPrice { get; }
        private bool IsBroken { get; }
        private int  Capacity { get; }

        protected Part(int durability, decimal buyPrice, decimal repairPrice, bool isBroken, int capacity)
        {
            Durability = durability;
            BuyPrice = buyPrice;
            RepairPrice = repairPrice;
            IsBroken = isBroken;
            Capacity = capacity;
        }

        public void decreaseDurability()
        {
            Durability -= 2;
        }
    }
}