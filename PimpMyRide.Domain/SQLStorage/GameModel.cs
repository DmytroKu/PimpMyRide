using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PimpMyRide.Domain.SQLStorage
{
    public class GameModel
    {
        [Key] public int Id { get; set; }
        [ForeignKey("CarId")]
        public int CarId { get; set; }
        [ForeignKey("PlayerId")]
        public int PlayerId { get; set; }

        public GameModel(int id, int carId, int playerId)
        {
            Id = id;
            CarId = carId;
            PlayerId = playerId;
        }
    }
}