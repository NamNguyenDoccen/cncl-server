using Core.MessageBus.Helpers;
using MassTransit;

namespace Core.MessageBus.Extensions;

public static class SendEndpointExtensions
{
    public static async Task SendAsync<TMessage>(this ISendEndpointProvider sendEndpointProvider, string queueName, TMessage message, CancellationToken ct)
        where TMessage : class
    {
        var endpoint = await sendEndpointProvider.GetSendEndpoint(new Uri(QueueHelper.GetFullQueueName(queueName)));
        await endpoint.Send(message, ct);
    }
}