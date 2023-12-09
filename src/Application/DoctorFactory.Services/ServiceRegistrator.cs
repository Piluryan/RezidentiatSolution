using Microsoft.Extensions.DependencyInjection;

namespace DoctorFactory.Services;
public static class ServiceRegistrator
{
    /// <summary> Extension method to configure and add Doctor Factory related services to the IServiceCollection. </summary>
    /// <param name="services">The IServiceCollection to which services should be added.</param>
    /// <returns>The updated IServiceCollection.</returns>
    public static IServiceCollection AddDoctorFactoryServices(this IServiceCollection services)
    {
        return services;
    }
}
