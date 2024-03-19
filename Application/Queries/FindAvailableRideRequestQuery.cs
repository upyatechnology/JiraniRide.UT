using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public class FindAvailableRideRequestQuery : IRequest<IEnumerable<DriverRouteCreate>>
    {
        public Location PickupLocation { get; set; }
        public double Radius { get; set; }
        // Other query properties
    }
}
