using System.ComponentModel.DataAnnotations;

namespace PimpMyRide.Domain.SQLStorage
{
    public class CarModel
    {
        [Key]//primary
        public int Id { get; set; }
        public int EngineId { get; set; } 
        public int AccumulatorId { get; set; }
        public int LeftFrontDiskId { get; set; }
        public int LeftRareDiskId { get; set; }
        public int RightFrontDiskId { get; set; }
        public int RightRareDiskId { get; set; }

        public CarModel(int id, int engineId, int accumulatorId, int leftFrontDiskId, int leftRareDiskId, int rightFrontDiskId, int rightRareDiskId)
        {
            Id = id;
            EngineId = engineId;
            AccumulatorId = accumulatorId;
            LeftFrontDiskId = leftFrontDiskId;
            LeftRareDiskId = leftRareDiskId;
            RightFrontDiskId = rightFrontDiskId;
            RightRareDiskId = rightRareDiskId;
        }

    }
}
