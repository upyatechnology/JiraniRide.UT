using Application.Contracts.Infrastructure;
using Confluent.Kafka;
using Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Messaging
{
    public class KafkaRiderRouteRequestProducer : IKafkaRiderRouteProducer
    {
        private readonly IConfiguration _configuration;
        private readonly IProducer<Null, string> _producer;

        public KafkaRiderRouteRequestProducer(IConfiguration configuration)
        {
            _configuration = configuration;

            var producerConfig = new ProducerConfig
            {
                BootstrapServers = _configuration["Kafka:BootstrapServers"]
            };
            _producer = new ProducerBuilder<Null, string>(producerConfig).Build();

        }
        public async Task PublishRoute(string topic, RiderRouteCreate route)
        {
            var message = JsonSerializer.Serialize(route);
            var kafkaMessage = new Message<Null, string> { Value = message };
            await _producer.ProduceAsync(topic, kafkaMessage);
        }
    }
}
