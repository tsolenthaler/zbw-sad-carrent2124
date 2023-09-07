namespace Zbw.Carrent.ReservationManagement.Api.Models
{
    public record RentalContractRequest(
        Guid Id,
        string ContractNr,
        Guid ReservationId,
        Guid CarId,
        Guid CustomerId
        );
}
