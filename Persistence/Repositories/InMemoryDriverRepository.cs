using Application.Commands;
using Application.Contracts.Persistance;
using Application.Models;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class InMemoryDriverRouteRepository : IDriverRouteRepository
    {
        private readonly Dictionary<string, DriverRouteCreate> _routes = new Dictionary<string, DriverRouteCreate>();
        public Task<int> AddAsync(DriverRouteCreate rideRequest)
        {
            _routes.Add("driver-created-route", rideRequest);
            return Task.FromResult(rideRequest.Id);
        }

        public Task<int> AddAsync(DriverCreatedTopic rideRequest)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(DriverRouteCreate entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(DriverCreatedTopic entity)
        {
            throw new NotImplementedException();
        }

        public Task<DriverRouteCreate> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CreateDriverRouteCommand> GetMatchedRoutesByAnyPickUPLocation(Location pickupLocation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CreateDriverRouteCommand> GetMatchedRoutesByDestinationLocation(Location destinationLocation)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CreateDriverRouteCommand> GetMatchedRoutesByStartingLocation(Location startingLocation)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<DriverRouteCreate>> ListAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DriverRouteCreate entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DriverCreatedTopic entity)
        {
            throw new NotImplementedException();
        }

       // Task<DriverRouteCreate> IAsyncRepository<DriverRouteCreate>.AddAsync(DriverRouteCreate entity) => throw new NotImplementedException();

        Task<DriverCreatedTopic> IAsyncRepository<DriverCreatedTopic>.AddAsync(DriverCreatedTopic entity)
        {
            throw new NotImplementedException();
        }

        Task<DriverCreatedTopic> IAsyncRepository<DriverCreatedTopic>.GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<DriverCreatedTopic> IDriverRouteRepository.GetMatchedRoutesByAnyPickUPLocation(Location pickupLocation)
        {
            throw new NotImplementedException();
        }

        IEnumerable<DriverCreatedTopic> IDriverRouteRepository.GetMatchedRoutesByDestinationLocation(Location destinationLocation)
        {
            throw new NotImplementedException();
        }

        IEnumerable<DriverCreatedTopic> IDriverRouteRepository.GetMatchedRoutesByStartingLocation(Location startingLocation)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<DriverCreatedTopic>> IAsyncRepository<DriverCreatedTopic>.ListAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
