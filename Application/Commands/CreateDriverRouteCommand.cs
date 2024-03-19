using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateDriverRouteCommand : IRequest<int>
    {
        public Driver Driver { get; set; }
        public Location StartLocation { get; set; }
        public List<Location> PickupLocations { get; set; }
        public Location DestinationLocation { get; set; }
        public DateTime? PickupTime { get; set; }
        public int NumberOfPassengers { get; set; }
        public string? Notes { get; set; }
        public float Price { get; set; }
        // Other command properties
    }
}
