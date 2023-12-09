using Microsoft.Extensions.DependencyInjection;

namespace DoctorFactory.DAL;
public static class ServiceRegistrator
{
    /// <summary> Extension method to configure and add infrastructure services to the IServiceCollection. </summary>
    /// <param name="services">The IServiceCollection to which services should be added.</param>
    /// <returns>The updated IServiceCollection.</returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        return services;
    }
}
