using Application.Contracts.Infrastructure;
using Confluent.Kafka;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Messaging
{
    //public class KafkaRouteConsumer : BackgroundService, IKafkaRouteConsumer
    public class KafkaDriverRouteConsumer :  IKafkaDriverRouteConsumer
    {
        private readonly IConsumer<Ignore, string> _consumer;

        private readonly ILogger<KafkaDriverRouteConsumer> _logger;

        public KafkaDriverRouteConsumer(IConfiguration configuration, ILogger<KafkaDriverRouteConsumer> logger)
        {
            _logger = logger;
            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"],
                GroupId = configuration["Kafka:GroupId"],
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
        }

        public IEnumerable<DriverRouteCreate> ConsumeDriverCreatedRoutes(string topic)
        {
            _consumer.Subscribe(topic);

            List<DriverRouteCreate> rideRequests = new List<DriverRouteCreate>();
            CancellationTokenSource cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) => {
                e.Cancel = true; // prevent the process from terminating.
                cts.Cancel();
            };
            try
            {
                while (true)
                {
                    try
                    {
                        var consumeResult = _consumer.Consume(cts.Token);
                        _logger.LogInformation($"Received Driver Created Route: {consumeResult.Message.Value}");
                        
                        // Process the consumed message (e.g., parse JSON, handle business logic)
                        var route = DeserializeRideRequest(consumeResult.Message.Value);
                        rideRequests.Add(route);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error occurred: {e.Message}");
                    }
                }
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError($"Error processing Kafka message: {ex.Message}");
                _consumer.Close();
            }
            return rideRequests;
        }


        private DriverRouteCreate DeserializeRideRequest(string message)
        {
            // Deserialize the message into a Route object
            // Example: Assuming the message is in JSON format
            return JsonConvert.DeserializeObject<DriverRouteCreate>(message);
        }
        
    }
}
