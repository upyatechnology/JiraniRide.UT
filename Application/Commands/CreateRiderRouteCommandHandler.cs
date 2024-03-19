using Application.Contracts.Infrastructure;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateRiderRouteCommandHandler : IRequestHandler<CreateRiderRouteCommand, int>
    {
        private readonly IKafkaRiderRouteProducer _producer;

        public CreateRiderRouteCommandHandler(IKafkaRiderRouteProducer producer)
        {
            _producer = producer;
        }
        public async Task<int> Handle(CreateRiderRouteCommand request, CancellationToken cancellationToken)
        {
            var route = new RiderRouteCreate() { EndLocation = request.EndLocation, StartLocation= request.EndLocation };
            // Handle command to create a route
            _producer.PublishRoute("rider-created-route", route);
            return await Task.FromResult(0);
        }
    }
}
