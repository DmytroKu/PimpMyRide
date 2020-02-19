namespace PimpMyRide.Domain.FileStorage
{
    public class PlayerModel
    {
        public decimal Money { get; set; }

        public PlayerModel(decimal money)
        {
            Money = money;
        }

        public PlayerModel()
        {
            
        }
    }
}