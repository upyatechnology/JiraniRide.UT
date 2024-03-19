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
    public class FindPublishedRoutesQueryHandler : IRequestHandler<FindPublishedRoutesQuery, IEnumerable<RiderRouteCreate>>
    {
        private readonly IKafkaRiderRouteConsumer _consumer;

        public FindPublishedRoutesQueryHandler(IKafkaRiderRouteConsumer consumer)
        {
            _consumer = consumer;
        }

        public async Task<IEnumerable<RiderRouteCreate>> Handle(FindPublishedRoutesQuery request, CancellationToken cancellationToken)
        {
            // Handle query to find published routes
            return _consumer.ConsumeRoutes("rider-created-route-topic");
        }
    }
}
