using Core.MessageBus.Helpers;
using MassTransit;

namespace Core.MessageBus.Extensions;

public static class RequestClientExtensions
{
    public static Task<Response<TResponse>> GetResponseForAsync<TRequest, TResponse>(this IScopedClientFactory factory, string queueName, TRequest message, CancellationToken ct)
        where TRequest : class
        where TResponse : class
    {
        var requestClient = factory.CreateRequestClient<TRequest>(new Uri(QueueHelper.GetFullQueueName(queueName)));
        return requestClient.GetResponse<TResponse>(message, ct, Constants.DefaultRequestTimeoutInSeconds);
    }

    public static Task<Response<TResponse1, TResponse2>> GetResponseForAsync<TRequest, TResponse1, TResponse2>(this IScopedClientFactory factory, string queueName, TRequest message, CancellationToken ct)
        where TRequest : class
        where TResponse1 : class
        where TResponse2 : class
    {
        var requestClient = factory.CreateRequestClient<TRequest>(new Uri(QueueHelper.GetFullQueueName(queueName)));
        return requestClient.GetResponse<TResponse1, TResponse2>(message, ct, Constants.DefaultRequestTimeoutInSeconds);
    }
}