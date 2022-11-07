﻿using Locaserv.Bdv.Api.Models;

namespace Locaserv.Bdv.Api.ViewModels;

public record DetailCarViewModel
{
    private DetailCarViewModel(Car car)
    {
        Uuid = car.Uuid;
        LicensePlate = car.LicensePlate;
        InternalCode = car.InternalCode;
    }

    public Guid Uuid { get; }
    public string LicensePlate { get; }
    public string InternalCode { get; }

    public static explicit operator DetailCarViewModel(Car car)
        => new(car);
}

public record CreateCarViewModel(string InternalCode, string LicensePlate)
{
    public static explicit operator Car(CreateCarViewModel car)
        => new()
        {
            InternalCode = car.InternalCode,
            LicensePlate = car.LicensePlate
        };
}
public record UpdateCarViewModel(Guid Uuid, string InternalCode, string LicensePlate)
{
    public static explicit operator Car(UpdateCarViewModel car)
        => new()
        {
            Uuid = car.Uuid,
            InternalCode = car.InternalCode,
            LicensePlate = car.LicensePlate
        };
}
public record DeleteCarViewModel(Guid Uuid);