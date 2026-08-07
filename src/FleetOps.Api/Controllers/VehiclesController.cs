using FleetOps.Api.Application.DTOs.Vehicles;
using FleetOps.Api.Application.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace FleetOps.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VehiclesController : ControllerBase
{
    private readonly IVehicleService _vehicleService;

    private readonly IValidator<CreateVehicleRequest> _createVehicleRequestValidator;

    public VehiclesController(IVehicleService vehicleService,
        IValidator<CreateVehicleRequest> createVehicleRequestValidator)
    {
        _vehicleService = vehicleService;
        _createVehicleRequestValidator = createVehicleRequestValidator;
    }

    [HttpPost]
    public async Task<ActionResult<VehicleResponse>> CreateVehicleAsync
        ([FromBody] CreateVehicleRequest createVehicleRequest, CancellationToken cancellationToken)
    {
        FluentValidation.Results.ValidationResult validationResult =
            await _createVehicleRequestValidator.ValidateAsync(
                createVehicleRequest, cancellationToken);

        if (!validationResult.IsValid)
        {
            foreach (ValidationFailure? error in validationResult.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }

            return ValidationProblem(ModelState);
        }
        try
        {
            VehicleResponse vehicleResponse = await _vehicleService.CreateAsync(
                createVehicleRequest, cancellationToken);
            return Created($"/api/vehicles/{vehicleResponse.Id}", vehicleResponse);

        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }
}
