using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class FindPublishedRoutesQuery : IRequest<IEnumerable<RiderRouteCreate>>
    {
    }
}