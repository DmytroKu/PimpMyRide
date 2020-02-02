namespace PimpMyRide.Domain
{
    public interface IRepository
    {
        Game? LoadGame();
        void SaveGame(Game game);
    }
}