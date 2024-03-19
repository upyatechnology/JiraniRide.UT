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
    public interface IRiderRouteRepository : IAsyncRepository<RiderCreatedTopic>
    {
        Task<int> AddAsync(RiderCreatedTopic route);

        IEnumerable<RiderCreatedTopic> GetMatchedRoutesByStartingLocation(Location startingLocation);
        IEnumerable<RiderCreatedTopic> GetMatchedRoutesByDestinationLocation(Location destinationLocation);
    }
}
