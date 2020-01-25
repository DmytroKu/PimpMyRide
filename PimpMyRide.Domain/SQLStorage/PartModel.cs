using System;
using System.Collections.Generic;
using System.Text;

namespace PimpMyRide.Domain.SQLStorage
{
    public class PartModel
    {
        public int Id { get; set; }
        public int Durability { get; set; }
        public decimal BuyPrice { get; set; }
        public decimal RepairPrice { get; set; }
        public bool IsBroken { get; set; }
        public int Capacity { get; set; }

        public int CarId { get;  set; }

        public PartModel(int id, int durability, decimal buyPrice, decimal repairPrice, bool isBroken, int capacity, int carId)
        {
            Id = id;
            Durability = durability;
            BuyPrice = buyPrice;
            RepairPrice = repairPrice;
            IsBroken = isBroken;
            Capacity = capacity;
            CarId = carId;
        }
    }
}
