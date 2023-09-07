namespace Zbw.Carrent.ReservationManagement.Api.Models
{
    public record ReservationRequest(
        Guid Id,
        DateTime StartDate,
        DateTime EndDate,
        Guid CarId,
        Guid CustomerId
        );
}
