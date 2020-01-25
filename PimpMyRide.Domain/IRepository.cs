namespace PimpMyRide.Domain
{
    public interface IRepository
    {
        Car? LoadCar();
        void SaveCar(Car car);
    }
}