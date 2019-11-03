using System.IO;
using System.Linq;
using System.Text.Json;

namespace PimpMyRide.Domain
{
    public class FileRepository
    {
        public static Car? LoadCar()
        {
            if (!File.Exists("car.json"))
                return null;
            var carString = File.ReadAllText("car.json");
            var carModel = JsonSerializer.Deserialize<CarModel>(carString);
            var engineModel = carModel.Engine!;
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
            return new Car(engine, accumulator, disks);
        }

        public static void SaveCar(Car car)
        {
            var engine = new PartModel(car.Engine.Durability,
                car.Engine.BuyPrice, car.Engine.RepairPrice,
                car.Engine.IsBroken, car.Engine.Capacity);
            var accumulator = new PartModel(car.Accumulator.Durability,
                car.Accumulator.BuyPrice, car.Accumulator.RepairPrice,
                car.Accumulator.IsBroken, car.Accumulator.Capacity);
            var disks = car.Disks.Select(x => new PartModel(x.Durability,
                x.BuyPrice, x.RepairPrice, x.IsBroken, x.Capacity)).ToArray();
            var carModel = new CarModel(engine, accumulator, disks);
            var carBytes = JsonSerializer.SerializeToUtf8Bytes(carModel);
            var carFile = File.Create("car.json");
            carFile.Write(carBytes,0,carBytes.Length);
            carFile.Close();
        }
    }
}