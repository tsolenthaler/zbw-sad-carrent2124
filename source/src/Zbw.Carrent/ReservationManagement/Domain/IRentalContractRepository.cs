namespace Zbw.Carrent.ReservationManagement.Domain
{
    public interface IRentalContractRepository
    {
        IEnumerable<RentalContract> GetAll();

        RentalContract Get(Guid id);

        void Add(RentalContract rentalContract);

        void Remove(RentalContract rentalContract);

        void Remove(Guid id);
    }
}
