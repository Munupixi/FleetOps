using FleetOps.Api.Application.DTOs.Vehicles;

namespace FleetOps.Api.Application.Interfaces;

public interface IVehicleService
{
    Task<VehicleResponse> CreateAsync(CreateVehicleRequest request,
        CancellationToken cancellationToken = default);
}
