using Application.Commands;
using Application.Contracts.Infrastructure;
using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RideApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RideController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IKafkaDriverRouteConsumer _consumer;

        public RideController(IMediator mediator, IKafkaDriverRouteConsumer consumer)
        {
            _mediator = mediator;
            _consumer = consumer;
        }

        [HttpPost("driverCreateRoute")]
        public async Task<IActionResult> DriverCreateRoute(CreateDriverRouteCommand command)
        {
            var rideRequestId = await _mediator.Send(command);
           // _consumer.ConsumeRoutes("route-topic");
            return Ok(rideRequestId);
        }

        [HttpPost("riderCreateRoute")]
        public async Task<IActionResult> RiderCreateRoute(CreateRiderRouteCommand command)
        {
            var routeId = await _mediator.Send(command);
           // _consumer.ConsumeRoutes("ride-request-topic");
            return Ok(routeId);
        }

        [HttpGet("availableDrivers")]
        public async Task<IActionResult> GetAvailableDrivers([FromQuery] FindAvailableRideRequestQuery query)
        {
            var drivers = await _mediator.Send(query);
            return Ok(drivers);
        }

        [HttpGet("availableRoutes")]
        public async Task<IActionResult> GetAvailableRoutes([FromQuery] FindPublishedRoutesQuery query)
        {
            var drivers = await _mediator.Send(query);
            return Ok(drivers);
        }
    }
}
