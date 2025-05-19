namespace Vilas.Utils.Messages.Kafka.Interfaces;

public interface IKafkaConsumer
{
    void Consume(string topic, Action<string> messageHandler, CancellationToken cancellationToken);
}
