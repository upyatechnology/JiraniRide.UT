using Application.Commands;
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
    public class RouteRepository : BaseRepository<RiderRouteCreate>, IRiderRouteRepository
    {
        public RouteRepository(JiraniDbContext dbContext): base(dbContext)
        {
            
        }

        public Task<int> AddAsync(RiderCreatedTopic route)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(RiderCreatedTopic entity)
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

        public Task UpdateAsync(RiderCreatedTopic entity)
        {
            throw new NotImplementedException();
        }

        //Task<int> IRiderRouteRepository.AddAsync(RiderRouteCreate route)
        //{
        //    throw new NotImplementedException();
        //}

        Task<RiderCreatedTopic> IAsyncRepository<RiderCreatedTopic>.AddAsync(RiderCreatedTopic entity)
        {
            throw new NotImplementedException();
        }

        Task<RiderCreatedTopic> IAsyncRepository<RiderCreatedTopic>.GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<RiderCreatedTopic> IRiderRouteRepository.GetMatchedRoutesByDestinationLocation(Location destinationLocation)
        {
            throw new NotImplementedException();
        }

        IEnumerable<RiderCreatedTopic> IRiderRouteRepository.GetMatchedRoutesByStartingLocation(Location startingLocation)
        {
            throw new NotImplementedException();
        }

        Task<IReadOnlyList<RiderCreatedTopic>> IAsyncRepository<RiderCreatedTopic>.ListAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
