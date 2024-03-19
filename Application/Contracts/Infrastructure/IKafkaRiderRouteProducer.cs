using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts.Infrastructure
{
    public interface IKafkaRiderRouteProducer
    {
        Task PublishRoute(string topic, RiderRouteCreate route);
    }
}
