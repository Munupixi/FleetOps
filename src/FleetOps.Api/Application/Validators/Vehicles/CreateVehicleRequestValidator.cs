using FleetOps.Api.Application.DTOs.Vehicles;
using FluentValidation;

namespace FleetOps.Api.Application.Validators.Vehicles;

public sealed class CreateVehicleRequestValidator : AbstractValidator<CreateVehicleRequest>
{
    private const int FirstAutomobileYear = 1886;
    public CreateVehicleRequestValidator()
    {
        RuleFor(x => x.PlateNumber)
            .NotEmpty()
            .MaximumLength(20);

        RuleFor(x => x.Vin)
            .NotEmpty()
            .Length(17);

        RuleFor(x => x.Brand)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Model)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Year)
            .InclusiveBetween(FirstAutomobileYear, DateTime.UtcNow.Year);

        RuleFor(x => x.Mileage)
            .GreaterThanOrEqualTo(0);

        RuleFor(x => x.FuelType)
            .IsInEnum();
    }
}
