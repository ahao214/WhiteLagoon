﻿namespace WhiteLagoon.Application.Common.Interface
{
    public interface IUnitOfWork
    {
        IVillaRepository Villa { get; }
        IVillaNumberRepository VillaNumber { get; }
        IAmenityRepository Amenity { get; }
        IBookingRepository Booking { get; }
        IApplicationUserRepository ApplicationUser { get; }

        void Save();
    }
}
