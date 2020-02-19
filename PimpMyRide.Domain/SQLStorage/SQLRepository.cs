using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PimpMyRide.Domain.SQLStorage
{
    public class SQLRepository : IRepository
    {
        private const int GameId = 1;
        private const int CarId = 1;
        private const int EngineId = 1;
        private const int PlayerId = 1;
        private const int AccumulatorId = 2;
        private const int LeftFrontDiskId = 3;
        private const int LeftRareDiskId = 4;
        private const int RightFrontDiskId = 5;
        private const int RightRareDiskId = 6;

        private static readonly int[] PartsId = new[]
            {EngineId, AccumulatorId, LeftFrontDiskId, LeftRareDiskId, RightFrontDiskId, RightRareDiskId};


        public Game? LoadGame()
        {
            using var context = new PimpMyRideContext();
            var gameModel = context.Games!.Find(GameId);
            if (gameModel == null) return null;
            var playerModel = context.Players.Single(x => x.Id == PlayerId);
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
            var car = new Car(Engine, Accumulator,
                new[] {LeftFrontDisk, LeftRareDisk, RightFrontDisk, RightRareDisk});
            var player =new Player(playerModel.Money);
            //Todo:load player DONE
            var game = new Game(car, player);
            return game;
        }

        public void SaveGame(Game game)
        {
            using var context = new PimpMyRideContext();
            //Todo: save player DONE
            var car = game.Car;
            var player = game.Player;
            var exists = context.Games!.AsNoTracking().Any(x => x.Id == GameId);

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
            var playerModel = new PlayerModel(PlayerId, player.Money);
            var gameModel = new GameModel(GameId, CarId, PlayerId);

            if (!exists)
            {
                context.Players!.AddRange(playerModel);
                context.Cars!.AddRange(carModel);
                context.Games!.AddRange(gameModel);
                context.Parts!.AddRange(partModels);
                
                
                
            }
            else
            {
                context.Parts!.UpdateRange(partModels);
                context.Cars!.UpdateRange(carModel);
                context.Players!.UpdateRange(playerModel);
                context.Games!.UpdateRange(gameModel);
            }

            context.SaveChanges();
        }
    }
}