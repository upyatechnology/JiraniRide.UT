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
    public class CreateDriverRouteCommandHandler : IRequestHandler<CreateDriverRouteCommand, int>
    {
        private readonly IKafkaRideRequestProducer _producer;

        public CreateDriverRouteCommandHandler(IKafkaRideRequestProducer producer)
        {
            _producer = producer;
        }
        public async Task<int> Handle(CreateDriverRouteCommand request, CancellationToken cancellationToken)
        {
            var rideRequest = new DriverRouteCreate() { DestinationLocation = request.DestinationLocation,
                  PickupLocation = request.PickupLocations};

            // Handle command to create a ride request
            _producer.PublishRideRequest("driver-created-route", rideRequest);
            return await Task.FromResult(0);
        }
    }
}
