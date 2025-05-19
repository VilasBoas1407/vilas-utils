namespace Vilas.Utils.Messages.Kafka.Interfaces
{
    public interface IKafkaProducer
    {
        Task ProduceAsync(string topic, string message);
    }
}
