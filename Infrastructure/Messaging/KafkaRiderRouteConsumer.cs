using Application.Contracts.Infrastructure;
using Confluent.Kafka;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Messaging
{

    public class KafkaRiderRouteConsumer : IKafkaRiderRouteConsumer
    {
        private readonly IConsumer<Ignore, string> _consumer;

        private readonly ILogger<KafkaRiderRouteConsumer> _logger;

        public KafkaRiderRouteConsumer(IConfiguration configuration, ILogger<KafkaRiderRouteConsumer> logger)
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

        public IEnumerable<RiderRouteCreate> ConsumeRoutes(string topic)
        {
            _consumer.Subscribe(topic);

            List<RiderRouteCreate> routes = new List<RiderRouteCreate>();
            CancellationTokenSource cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) =>
            {
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
                        _logger.LogInformation($"Received Rider Route Created: {consumeResult.Message.Value}");
                        // Process the consumed message (e.g., parse JSON, handle business logic)
                        var route = DeserializeRoute(consumeResult.Message.Value);
                        routes.Add(route);
                    }
                    catch (Exception e)
                    {
                        _logger.LogInformation($"Error occurred: {e.Message}");
                    }
                }
            }
            catch (OperationCanceledException ex)
            {
                _logger.LogError($"Error processing Kafka message: {ex.Message}");
                _consumer.Close();
            }
            return routes;
        }

        private RiderRouteCreate DeserializeRoute(string message)
        {
            // Deserialize the message into a Route object
            // Example: Assuming the message is in JSON format
            return JsonConvert.DeserializeObject<RiderRouteCreate>(message);
        }

    }
    }
