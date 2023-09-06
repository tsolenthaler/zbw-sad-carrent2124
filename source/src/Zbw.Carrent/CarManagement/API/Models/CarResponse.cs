using Zbw.Carrent.CarManagement.Domain;

namespace Zbw.Carrent.CarManagement.Api.Models
{
    public record CarResponse(
        Guid id,
        string CarNr,
        CarBrand CarBrand,
        CarCategory CarCategory,
        CarModel CarModel
        );
}
