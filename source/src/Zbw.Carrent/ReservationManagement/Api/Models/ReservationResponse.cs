namespace Zbw.Carrent.ReservationManagement.Api.Models
{
    public record ReservationResponse(
        Guid Id,
        DateTime StartDate,
        DateTime EndDate,
        Guid CarId,
        Guid CustomerId
        );
}
