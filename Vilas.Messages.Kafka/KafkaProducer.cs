using Confluent.Kafka;
using Vilas.Utils.Messages.Kafka.Interfaces;

namespace Vilas.Utils.Messages.Kafka;

public class KafkaProducer : IKafkaProducer
{
    private readonly IProducer<Null, string> _producer;

    public KafkaProducer(KafkaConfig config)
    {
        var producerConfig = new ProducerConfig
        {
            BootstrapServers = config?.BootstrapServers ?? "localhost:9092"
        };

        _producer = new ProducerBuilder<Null, string>(producerConfig).Build();
    }

    public async Task ProduceAsync(string topic, string message)
    {
        var msg = new Message<Null, string> { Value = message };
        await _producer.ProduceAsync(topic, msg);
    }
}
