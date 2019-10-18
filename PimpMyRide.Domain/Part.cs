namespace PimpMyRide.Domain
{
   public abstract class Part
    {
        private int  Durability { get; set; }
        private decimal BuyPrice { get; }
        private decimal RepairPrice { get; }
        public bool IsBroken => Durability <= 0;
        private int  Capacity { get; }

        protected Part(int durability, decimal buyPrice, decimal repairPrice, int capacity)
        {
            Durability = durability;
            BuyPrice = buyPrice;
            RepairPrice = repairPrice;
            Capacity = capacity;
        }

        public void DecreaseDurability()
        {
            Durability--;
        }

        public void Repair()
        {
            Durability++;
        }

        
    }
}