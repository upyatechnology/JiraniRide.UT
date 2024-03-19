using Application.Commands;
using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Persistance
{
    public interface IDriverRouteRepository : IAsyncRepository<DriverCreatedTopic>
    {
        Task<int> AddAsync(DriverCreatedTopic rideRequest);

        IEnumerable<DriverCreatedTopic> GetMatchedRoutesByStartingLocation(Location startingLocation);
        IEnumerable<DriverCreatedTopic> GetMatchedRoutesByDestinationLocation(Location destinationLocation);
        IEnumerable<DriverCreatedTopic> GetMatchedRoutesByAnyPickUPLocation(Location pickupLocation);
    }
}
