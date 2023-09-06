using System.ComponentModel;

namespace Zbw.Carrent.CarManagement.Domain
{
    public class Car
    {
        public Car(string carNr, string name)
        {
            Id = Guid.NewGuid();
            CarNr = carNr;
            Name = name;
        }

        public Guid Id { get; }

        public string CarNr { get; }

        public string Name { get; }
        public CarCategory carCategory { get; set; }
        public CarBrand carBrand { get; set; }
        public CarModel carModel { get; set; }

    }
}
