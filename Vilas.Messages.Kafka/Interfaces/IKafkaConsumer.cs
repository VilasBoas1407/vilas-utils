namespace Vilas.Messages.Kafka.Interfaces;

public interface IKafkaConsumer
{
    void Consume(string topic, Action<string> messageHandler, CancellationToken cancellationToken);
}
