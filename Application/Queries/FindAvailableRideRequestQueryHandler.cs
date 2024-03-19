using Application.Contracts.Infrastructure;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class FindAvailableRideRequestQueryHandler : IRequestHandler<FindAvailableRideRequestQuery, IEnumerable<DriverRouteCreate>>
    {
        private readonly IKafkaDriverRouteConsumer _consumer;

        public FindAvailableRideRequestQueryHandler(IKafkaDriverRouteConsumer consumer)
        {
            _consumer = consumer;
        }
        public async Task<IEnumerable<DriverRouteCreate>> Handle(FindAvailableRideRequestQuery request, CancellationToken cancellationToken)
        {
            // Handle query to find available drivers
            return _consumer.ConsumeDriverCreatedRoutes("driver-created-route-topic");
        }
    }
}
