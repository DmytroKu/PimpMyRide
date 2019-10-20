using System;

namespace PimpMyRide.Domain
{
    public abstract class Part
    {
        public int Durability {   get;  private set; }
        public decimal BuyPrice { get; }
        public decimal RepairPrice { get; }
        public bool IsBroken => Durability <= 0;
        public int Capacity { get;  private set;}

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
            Durability--;
        }

        public void Repair()
        {
            Durability=100;
            Capacity-=10;
        }

        public void Replace()
        {
            Durability = 100;
            Capacity = 100;
            
        }

        public (bool repairable, decimal price,bool isBroken) CanRepair => (Capacity > 0, RepairPrice,IsBroken);
    }
}