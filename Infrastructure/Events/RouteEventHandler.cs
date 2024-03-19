using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Events
{
    public class RouteEventHandler : INotificationHandler<RouteCreatedEvent>
    {
        public async Task Handle(RouteCreatedEvent notification, CancellationToken cancellationToken)
        {
            // Handle route created event
            throw new NotImplementedException();
        }
    }
}
