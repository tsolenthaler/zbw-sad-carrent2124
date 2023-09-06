namespace Zbw.Carrent.CarManagement.Domain
{
    public class CarModel
    {
        public CarModel(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Guid Id { get; }

        public string Name { get; }

    }
}
