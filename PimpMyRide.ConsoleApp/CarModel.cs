namespace PimpMyRide.ConsoleApp
{
    public class CarModel
    {
        public PartModel? Engine { get;  set; }
        public PartModel? Accumulator { get;  set; }
        public PartModel[]? Disks { get; set; }

        public CarModel()
        {
            
        }
        public CarModel(PartModel engine, PartModel accumulator, PartModel[] disks)
        {
            Engine = engine;
            Accumulator = accumulator;
            Disks = disks;
        }

    }
}