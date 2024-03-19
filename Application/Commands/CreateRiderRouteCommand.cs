using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public class CreateRiderRouteCommand : IRequest<int>
    {
        public Rider Rider { get; set; }
        public Location StartLocation { get; set; }
        public Location EndLocation { get; set; }
        // Other command properties
    }
}
