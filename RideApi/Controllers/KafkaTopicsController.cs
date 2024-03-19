using Confluent.Kafka;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RideApi.Services;
using static Confluent.Kafka.ConfigPropertyNames;

namespace RideApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KafkaTopicsController : ControllerBase
    {
        private readonly KafkaRiderTopicConsumer _kafkaRiderConsumer;
        private readonly KafkaDriverTopicConsumer _kafkaDriverConsumer;
        

        public KafkaTopicsController(KafkaRiderTopicConsumer kafkaConsumer, KafkaDriverTopicConsumer kafkaDriverConsumer)
        {
            // Initialize Kafka consumer configuration
            _kafkaRiderConsumer = kafkaConsumer;
            _kafkaDriverConsumer = kafkaDriverConsumer;
        }

        [HttpGet("ridertopic")]
        public ActionResult<IEnumerable<string>> GetMessagesFromTopic(string topic, [FromQuery] int maxMessages = 10)
        {
            var messages = _kafkaRiderConsumer.GetMessagesFromTopic(topic, maxMessages);
            return Ok(messages);
        }

        [HttpGet("Drivertopic")]
        public ActionResult<IEnumerable<string>> GetDriverMessagesFromTopic(string topic, [FromQuery] int maxMessages = 10)
        {
            var messages = _kafkaDriverConsumer.GetDriverMessagesFromTopic(topic, maxMessages);
            return Ok(messages);
        }
    }
}
