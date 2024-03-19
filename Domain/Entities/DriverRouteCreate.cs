using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class DriverRouteCreate : AuditableEntity
    {
        public int Id { get; set; }
        public Location StartLocation { get; set; }

        public List<Location>? PickupLocation { get; set; }

        public Location DestinationLocation { get; set; }
        
    }
}
