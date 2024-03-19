using Application.Contracts.Infrastructure;
using Confluent.Kafka;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Messaging
{
    public class KafkaDriverRouteRequestProducer : IKafkaRideRequestProducer
    {
        private readonly IConfiguration _configuration;
        private readonly IProducer<Null, string> _producer;

        public KafkaDriverRouteRequestProducer(IConfiguration configuration)
        {
            _configuration = configuration;

            var producerConfig = new ProducerConfig
            {
                BootstrapServers = _configuration["Kafka:BootstrapServers"]
            };
            _producer = new ProducerBuilder<Null, string>(producerConfig).Build();
        }
        public async Task PublishRideRequest(string topic, DriverRouteCreate rideRequest)
        {
            var message = JsonSerializer.Serialize(rideRequest);
            var kafkaMessage = new Message<Null, string> { Value = message };
            await _producer.ProduceAsync(topic, kafkaMessage);
        }
    }
}
