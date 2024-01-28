using DoctorFactory.Interfaces.Services;
using DoctorFactory.Services.Courses.InSQL;
using DoctorFactory.Services.Data;
using Microsoft.Extensions.DependencyInjection;

namespace DoctorFactory.Services;
public static class ServiceRegistrator
{
    /// <summary> Extension method to configure and add application services to the IServiceCollection. </summary>
    /// <param name="services">The IServiceCollection to which services should be added.</param>
    /// <returns>The updated IServiceCollection.</returns>
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services
            .AddTransient<RezitentiatDbInitializer>()
            .AddTransient<ICourse, SqlCourses>()
            ;

        return services;
    }
}
