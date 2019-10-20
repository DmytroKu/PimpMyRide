using System;

namespace PimpMyRide.Domain
{
    public abstract class Part
    {
        private int Durability { get; set; }
        private decimal BuyPrice { get; }
        private decimal RepairPrice { get; }
        public bool IsBroken => Durability <= 0;
        private int Capacity { get; set; }

        protected Part(int durability, decimal buyPrice, decimal repairPrice, int capacity)
        {
            if (durability <= 0 || durability > 100) throw new ArgumentOutOfRangeException(nameof(durability));
            if (capacity <= 0 || capacity > 100) throw new ArgumentOutOfRangeException(nameof(capacity));
            Durability = durability;
            BuyPrice = buyPrice;
            RepairPrice = repairPrice;
            Capacity = capacity;
        }

        public void DecreaseDurability()
        {
            Durability-=5;
        }

        public void Repair()
        {
            Durability+=10;
            Capacity-=10;
        }

        public void Replace()
        {
            Durability = 100;
            Capacity = 100;
            
        }

        public (bool repairable, decimal price,int Durability,int Capacity) CanRepair => (Capacity > 0, RepairPrice,Durability,Capacity);
        public decimal ReplaceCost => BuyPrice;
        public int GetDurability => Durability;
        public int GetCapacily => Capacity;
    }
}