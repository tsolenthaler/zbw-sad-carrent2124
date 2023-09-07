using Zbw.Carrent.CarManagement.Domain;
using Zbw.Carrent.CustomerManagement.Domain;

namespace Zbw.Carrent.ReservationManagement.Domain
{
    public class Reservation
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid CarId { get; set; }
        public Car Car { get; set; }
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
