using System.ComponentModel.DataAnnotations;

namespace PimpMyRide.Domain.SQLStorage
{
    public class PlayerModel
    {
        [Key]public int Id { get; set; }
        public decimal Money { get; set; }

        public PlayerModel(int id, decimal money)
        {
            Id = id;
            Money = money;
        }
    }
}