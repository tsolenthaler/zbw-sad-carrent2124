namespace Zbw.Carrent.ReservationManagement.Api.Models
{
    public record RentalContractResponse(
        Guid Id,
        string ContractNr,
        Guid ReservationId,
        Guid CarId,
        Guid CustomerId
        );
}
