
namespace ContactRegistration.WebAPI.Extentions;

/// <summary>
/// Defines the <see cref="ApplicationServiceExtention" />.
/// </summary>
public static class ApplicationServiceExtention
{
    /// <summary>
    /// The ConfigureApplicationServices.
    /// </summary>
    /// <param name="services">The services<see cref="IServiceCollection"/>.</param>
    /// <returns>The <see cref="IServiceCollection"/>.</returns>
    public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly(), Assembly.Load("ContactRegistration.Application"));
        services.AddMediatR(cfg => cfg            
            .RegisterServicesFromAssembly(Assembly.Load("ContactRegistration.Application"))
        );
        
        // Configure Swagger
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Contact Registration",
                Version = "v1",
                Description = "This is a simple application for contact registration",
            });
        });

        return services;
    }
}

