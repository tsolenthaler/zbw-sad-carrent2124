using Zbw.Carrent.CarManagement.Domain;

namespace Zbw.Carrent.CarManagement.Api.Models
{
    public record CarRequest(
        Guid Id,
        string CarNr,
        CarBrand carBrand,
        CarCategory carCategory,
        CarModel carModel
        );

}
