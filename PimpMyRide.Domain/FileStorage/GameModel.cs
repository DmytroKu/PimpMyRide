namespace PimpMyRide.Domain.FileStorage
{
    public class GameModel
    {
        public PlayerModel? Player { get; set; }
        public CarModel? Car { get; set; }

        public GameModel(PlayerModel player, CarModel car)
        {
            Player = player;
            Car = car;
        }

        public GameModel()
        {
            
        }
        
    }
}