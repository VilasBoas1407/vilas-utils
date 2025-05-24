using Confluent.Kafka;
using Vilas.Utils.Messages.Kafka.Interfaces;

namespace Vilas.Utils.Messages.Kafka;

public class KafkaConsumer : IKafkaConsumer
{
    private readonly ConsumerConfig _config;

    public KafkaConsumer(KafkaConfig config)
    {
        _config = new ConsumerConfig
        {
            BootstrapServers = config.BootstrapServers,
            GroupId = config.GroupId,
            AutoOffsetReset = config.OffsetReset
        };
    }

    public void Consume(string topic, Action<string> messageHandler, CancellationToken cancellationToken)
    {
        using var consumer = new ConsumerBuilder<Ignore, string>(_config).Build();
        consumer.Subscribe(topic);

        while (!cancellationToken.IsCancellationRequested)
        {
            try
            {
                var cr = consumer.Consume(cancellationToken);
                messageHandler(cr.Message.Value);
            }
            catch (OperationCanceledException)
            {
                consumer.Close();
                break;
            }
        }
    }
}
