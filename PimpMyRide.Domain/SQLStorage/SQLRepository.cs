using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace PimpMyRide.Domain.SQLStorage
{
    public class SQLRepository : IRepository
    {
        private const int CarId = 1;
        private const int EngineId = 1;
        private const int AccumulatorId = 2;
        private const int LeftFrontDiskId = 3;
        private const int LeftRareDiskId = 4;
        private const int RightFrontDiskId = 5;
        private const int RightRareDiskId = 6;

        private static readonly int[] PartsId = new[]
            {EngineId, AccumulatorId, LeftFrontDiskId, LeftRareDiskId, RightFrontDiskId, RightRareDiskId};


        public Car? LoadCar()
        {
            using var context = new PimpMyRideContext();
            var carModel = context.Cars!.Find(CarId);
            if (carModel == null)
            {
                return null;
            }

            var partModels = context.Parts!.Where(x => PartsId.Contains(x.Id)).ToList();
            var engine = partModels.Single(x => x.Id == EngineId);
            var Engine = new Engine(engine.Durability, engine.BuyPrice, engine.RepairPrice, engine.Capacity);
            var accumulator = partModels.Single(x => x.Id == AccumulatorId);
            var Accumulator = new Accumulator(accumulator.Durability, accumulator.BuyPrice, accumulator.RepairPrice,
                accumulator.Capacity);
            var leftFrontDiskModel = partModels.Single(x => x.Id == LeftFrontDiskId);
            var LeftFrontDisk = new Disk(leftFrontDiskModel.Durability, leftFrontDiskModel.BuyPrice,
                leftFrontDiskModel.RepairPrice, leftFrontDiskModel.Capacity);
            var leftRareDiskModel = partModels.Single(x => x.Id == LeftRareDiskId);
            var LeftRareDisk = new Disk(leftRareDiskModel.Durability, leftRareDiskModel.BuyPrice,
                leftRareDiskModel.RepairPrice, leftRareDiskModel.Capacity);

            var rightFrontDiskModel = partModels.Single(x => x.Id == RightFrontDiskId);
            var RightFrontDisk = new Disk(rightFrontDiskModel.Durability, rightFrontDiskModel.BuyPrice,
                rightFrontDiskModel.RepairPrice, rightFrontDiskModel.Capacity);

            var rightRareDiskModel = partModels.Single(x => x.Id == RightRareDiskId);
            var RightRareDisk = new Disk(rightRareDiskModel.Durability, rightRareDiskModel.BuyPrice,
                rightRareDiskModel.RepairPrice, rightRareDiskModel.Capacity);

            return new Car(Engine, Accumulator, new[] {LeftFrontDisk, LeftRareDisk, RightFrontDisk, RightRareDisk});
        }

        public void SaveCar(Car car)
        {
            using var context = new PimpMyRideContext();

            var exists = context.Cars!.AsNoTracking().Any(x => x.Id == CarId);

            var partModels = new[]
            {
                new PartModel(EngineId, car.Engine.Durability, car.Engine.BuyPrice, car.Engine.RepairPrice,
                    car.Engine.IsBroken, car.Engine.Capacity, CarId),
                new PartModel(AccumulatorId, car.Accumulator.Durability, car.Accumulator.BuyPrice,
                    car.Accumulator.RepairPrice,
                    car.Accumulator.IsBroken, car.Accumulator.Capacity, CarId),
                new PartModel(LeftFrontDiskId, car.Disks[0].Durability, car.Disks[0].BuyPrice,
                    car.Disks[0].RepairPrice,
                    car.Disks[0].IsBroken, car.Disks[0].Capacity, CarId),
                new PartModel(LeftRareDiskId, car.Disks[1].Durability, car.Disks[1].BuyPrice,
                    car.Disks[1].RepairPrice,
                    car.Disks[1].IsBroken, car.Disks[1].Capacity, CarId),
                new PartModel(RightFrontDiskId, car.Disks[2].Durability, car.Disks[2].BuyPrice,
                    car.Disks[2].RepairPrice,
                    car.Disks[2].IsBroken, car.Disks[2].Capacity, CarId),
                new PartModel(RightRareDiskId, car.Disks[3].Durability, car.Disks[3].BuyPrice,
                    car.Disks[3].RepairPrice,
                    car.Disks[3].IsBroken, car.Disks[3].Capacity, CarId),
            };
            var carModel = new CarModel(CarId, EngineId, AccumulatorId, LeftFrontDiskId, LeftRareDiskId,
                RightFrontDiskId,
                RightRareDiskId);
            if (!exists)
            {
                context.Parts!.AddRange(partModels);
                context.Cars!.AddRange(carModel);
            }
            else
            {
                context.Parts!.UpdateRange(partModels);
                context.Cars!.UpdateRange(carModel);
            }

            context.SaveChanges();
        }
    }
}