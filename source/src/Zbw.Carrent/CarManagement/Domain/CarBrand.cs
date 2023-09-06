namespace Zbw.Carrent.CarManagement.Domain
{
    public class CarBrand
    {
        public CarBrand(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }

        public Guid Id { get; }

        public string Name { get; }
    }
}
