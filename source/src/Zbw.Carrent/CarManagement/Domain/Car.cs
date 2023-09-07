using System.ComponentModel;

namespace Zbw.Carrent.CarManagement.Domain
{
    public class Car
    {
        public Guid Id { get; }
        public string CarNr { get; }
        public CarCategory CarCategory { get; set; }
        public CarBrand CarBrand { get; set; }
        public CarModel CarModel { get; set; }

    }
}
