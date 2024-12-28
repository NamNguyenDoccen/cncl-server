using Microsoft.Extensions.DependencyInjection;

namespace Core.DI;

public static class Extensions
{
    public static IServiceCollection AddServices(this IServiceCollection services) =>
        services
            .AddServicesByInterfaceType(typeof(ITransientService), ServiceLifetime.Transient)
            .AddServicesByInterfaceType(typeof(IScopedService), ServiceLifetime.Scoped)
            .AddServicesByInterfaceType(typeof(ISingletonService), ServiceLifetime.Singleton);

    public static IServiceCollection AddServicesByInterfaceType(this IServiceCollection services, Type iServiceType, ServiceLifetime lifetime)
    {
        var types = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => iServiceType.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);

        foreach (var type in types)
        {
            var interfaces = type.GetInterfaces();
            foreach (var @interface in interfaces)
            {
                services.Add(new ServiceDescriptor(@interface, type, lifetime));
            }
        }

        return services;
    }
}