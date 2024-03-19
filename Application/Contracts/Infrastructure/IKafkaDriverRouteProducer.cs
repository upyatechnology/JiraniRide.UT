using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Infrastructure
{
    public interface IKafkaRideRequestProducer
    {
        Task PublishRideRequest(string topic, DriverRouteCreate rideRequest);
    }
}
