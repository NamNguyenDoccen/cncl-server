namespace Core.MessageBus;

public static class Constants
{
    public const string DotNetRunningInDocker = "DOTNET_RUNNING_IN_CONTAINER";
    public static readonly TimeSpan DefaultRequestTimeoutInSeconds = TimeSpan.FromSeconds(60);
    public static class QueueNames
    { }

    public static class RabbitMqHost
    {
        public const string DifferentNetworkRabbitMqHost = "rabbitmq://localhost";
        public const string SameNetworkRabbitMqHost = "rabbitmq";
    }
}