using Application.Contracts.Persistance;
using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class RideRequestRepository : BaseRepository<DriverRouteCreate>, IDriverRouteRepository
    {
        public RideRequestRepository(JiraniDbContext dbContext) :base(dbContext)
        {
            
        }

        public Task<int> AddAsync(DriverCreatedTopic rideRequest)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(DriverCreatedTopic entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DriverCreatedTopic> GetMatchedRoutesByAnyPickUPLocation(Location pickupLocation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DriverCreatedTopic> GetMatchedRoutesByDestinationLocation(Location destinationLocation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DriverCreatedTopic> GetMatchedRoutesByStartingLocation(Location startingLocation)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DriverCreatedTopic entity)
        {
            throw new NotImplementedException();
        }

        Task<DriverCreatedTopic> IAsyncRepository<DriverCreatedTopic>.AddAsync(DriverCreatedTopic entity)
        {
            throw new NotImplementedException();
        }

        Task<DriverCreatedTopic> IAsyncRepository<DriverCreatedTopic>.GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<DriverCreatedTopic>> IAsyncRepository<DriverCreatedTopic>.ListAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
