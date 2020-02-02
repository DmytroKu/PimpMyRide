namespace PimpMyRide.Domain
{
    public class Game
    {
        public Car Car { get; }
        public Player Player { get; }

        public Game(Car car, Player player)
        {
            Car = car;
            Player = player;
        }

    }
}