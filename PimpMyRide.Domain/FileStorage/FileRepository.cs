using System.IO;
using System.Linq;
using System.Text.Json;

namespace PimpMyRide.Domain.FileStorage
{
    public class FileRepository : IRepository
    {
        public Game? LoadGame()
        {
            if (!File.Exists("game.json"))
                return null;
            var gameString = File.ReadAllText("game.json");
            var gameModel = JsonSerializer.Deserialize<GameModel>(gameString);
            var carModel = gameModel.Car;
            var engineModel = carModel!.Engine!;
            var engine = new Engine(engineModel.Durability, engineModel.BuyPrice,
                engineModel.RepairPrice, engineModel.Capacity);
            var accumulatorModel = carModel.Accumulator!;
            var accumulator = new Accumulator(
                accumulatorModel.Durability,
                accumulatorModel.BuyPrice,
                accumulatorModel.RepairPrice,
                accumulatorModel.Capacity);
            var disks = carModel.Disks
                    !.Select(x => new Disk(x.Durability, x.BuyPrice, x.RepairPrice, x.Capacity))
                .ToArray();
            var car = new Car(engine, accumulator, disks);
            var playerModel = gameModel.Player;
            var player = new Player(playerModel!.Money);

            return new Game(car ,player);
        }

        public void SaveGame(Game game)
        {
            var car = game.Car;
            var engine = new PartModel(car.Engine.Durability,
                car.Engine.BuyPrice, car.Engine.RepairPrice,
                car.Engine.IsBroken, car.Engine.Capacity);
            var accumulator = new PartModel(car.Accumulator.Durability,
                car.Accumulator.BuyPrice, car.Accumulator.RepairPrice,
                car.Accumulator.IsBroken, car.Accumulator.Capacity);
            var disks = car.Disks.Select(x => new PartModel(x.Durability,
                x.BuyPrice, x.RepairPrice, x.IsBroken, x.Capacity)).ToArray();
            var carModel = new CarModel(engine, accumulator, disks);
            var player = game.Player;
            var playerModel = new PlayerModel(player.Money);
            var gameModel = new GameModel(playerModel,carModel);
            var gameBytes = JsonSerializer.SerializeToUtf8Bytes(gameModel);
            var gameFile = File.Create("game.json");
            gameFile.Write(gameBytes, 0, gameBytes.Length);
            gameFile.Close();
        }
    }
}