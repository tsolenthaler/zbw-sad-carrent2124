namespace Zbw.Carrent.CarManagement.Domain
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAll();
        Car Get(Guid id);
        void Add(Car car);
        void Remove(Car car);
        void Remove(Guid id);

    }
}
