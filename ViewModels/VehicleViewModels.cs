using Locaserv.Bdv.Api.Models;

namespace Locaserv.Bdv.Api.ViewModels;

public record DetailVehicleViewModel
{
    private DetailVehicleViewModel(Vehicle vehicle)
    {
        Uuid = vehicle.Uuid;
        LicensePlate = vehicle.LicensePlate;
        InternalCode = vehicle.InternalCode;
    }

    public Guid Uuid { get; }
    public string LicensePlate { get; }
    public string InternalCode { get; }

    public static explicit operator DetailVehicleViewModel(Vehicle vehicle)
        => new(vehicle);
}

public record CreateVehicleViewModel(string InternalCode, string LicensePlate)
{
    public static explicit operator Vehicle(CreateVehicleViewModel vehicle)
        => new()
        {
            InternalCode = vehicle.InternalCode,
            LicensePlate = vehicle.LicensePlate
        };
}
public record UpdateVehicleViewModel(Guid Uuid, string InternalCode, string LicensePlate)
{
    public static explicit operator Vehicle(UpdateVehicleViewModel vehicle)
        => new()
        {
            Uuid = vehicle.Uuid,
            InternalCode = vehicle.InternalCode,
            LicensePlate = vehicle.LicensePlate
        };
}
public record DeleteVehicleViewModel(Guid Uuid);