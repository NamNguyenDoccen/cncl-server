﻿namespace Core.MessageBus.Helpers;

public static class QueueHelper
{
    public static string GetFullQueueName(string queueName)
    {
        return $"queue:{queueName}";
    }

    public static string GetRabbitMqHost()
    {
        bool inDocker = bool.TryParse(Environment.GetEnvironmentVariable(Constants.DotNetRunningInDocker), out _);
        return inDocker ? Constants.RabbitMqHost.SameNetworkRabbitMqHost : Constants.RabbitMqHost.DifferentNetworkRabbitMqHost;
    }
}