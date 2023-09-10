namespace Zbw.Carrent.CustomerManagement.Api.Models
{
    public record CustomerRequest(
        Guid Id,
        string CustomerNr,
        string Name,
        string Address,
        string FullName
    );
}
