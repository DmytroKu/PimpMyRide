namespace PimpMyRide.Domain
{
    public class PartModel
    {
        public int Durability { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal RepairPrice { get; set; }
        public bool IsBroken { get; set; }
        public int Capacity { get; set; }

        public PartModel()
        {
            
        }
        public PartModel(int durability, decimal buyPrice, decimal repairPrice, bool isBroken, int capacity)
        {
            Durability = durability;
            BuyPrice = buyPrice;
            RepairPrice = repairPrice;
            IsBroken = isBroken;
            Capacity = capacity;
        }
    }
}