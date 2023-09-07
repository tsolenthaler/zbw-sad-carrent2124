namespace Zbw.Carrent.ReservationManagement.Domain
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAll();

        Reservation Get(Guid id);

        void Add(Reservation reservation);

        void Remove(Reservation reservation);

        void Remove(Guid id);
    }
}
