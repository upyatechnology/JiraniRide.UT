using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Events
{
    public class RideRequestEventHandler : INotificationHandler<RideRequestCreatedEvent>
    {
        public async Task Handle(RideRequestCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Handle ride request created event
            throw new NotImplementedException();
        }
    }

}
