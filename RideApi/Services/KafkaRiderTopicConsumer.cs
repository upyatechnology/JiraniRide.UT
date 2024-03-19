using Confluent.Kafka;

namespace RideApi.Services
{
    
    public class KafkaRiderTopicConsumer : BackgroundService
    {
        private readonly IConsumer<Ignore, string> _consumer;

        private readonly ILogger<KafkaRiderTopicConsumer> _logger;

        public KafkaRiderTopicConsumer(IConfiguration configuration, ILogger<KafkaRiderTopicConsumer> logger)
        {
            _logger = logger;

            var consumerConfig = new ConsumerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"],
                GroupId = "jirani-ride-group",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _consumer.Subscribe("driver-created-route");

            while (!stoppingToken.IsCancellationRequested)
            {
                ProcessKafkaMessage(stoppingToken);

                await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
            }

            _consumer.Close();
        }

        public void ProcessKafkaMessage(CancellationToken stoppingToken)
        {
            try
            {
                var consumeResult = _consumer.Consume(stoppingToken);

                var message = consumeResult.Message.Value;

                _logger.LogInformation($"Received Ride Created: {message}");
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error processing Kafka message: {ex.Message}");
            }
        }

        public IEnumerable<string> GetMessagesFromTopic(string topic, int maxMessages)
        {
            _consumer.Subscribe(topic);

            var messages = new List<string>();
            while (messages.Count < maxMessages)
            {
                var consumeResult = _consumer.Consume(TimeSpan.FromSeconds(5));
                if (consumeResult != null)
                {
                    messages.Add(consumeResult.Message.Value);
                }
                else
                {
                    // No more messages available, break the loop
                    break;
                }
            }

            return messages;
        }
    }
}
