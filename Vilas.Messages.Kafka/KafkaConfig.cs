using Confluent.Kafka;

namespace Vilas.Utils.Messages.Kafka;

public class KafkaConfig
{
    public string BootstrapServers { get; set; } = "localhost:9092";
    public string GroupId { get; set; } = "default-group";
    public AutoOffsetReset OffsetReset { get; set; } = AutoOffsetReset.Earliest;
}
