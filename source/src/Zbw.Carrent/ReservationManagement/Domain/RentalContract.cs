using Zbw.Carrent.CarManagement.Domain;
using Zbw.Carrent.CustomerManagement.Domain;

namespace Zbw.Carrent.ReservationManagement.Domain
{
    public class RentalContract
    {
        public Guid Id { get; set; }
        public string ContractNr { get; set; }
        public Guid ReservationId { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
