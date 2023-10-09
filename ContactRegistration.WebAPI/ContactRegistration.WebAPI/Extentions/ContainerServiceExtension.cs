
namespace ContactRegistration.WebAPI.Extentions;

/// <summary>
/// Defines the <see cref="ContainerServiceExtension" />.
/// </summary>

public static class ContainerServiceExtension
{
    /// <summary>
    /// Defines the <see cref="ConfigureAutoFacContainer" />.
    /// </summary>
    /// <param name="appBuilder"><see cref="WebApplicationBuilder"/></param>
    public static void ConfigureAutoFacContainer(this WebApplicationBuilder builder)
    {
        Batteries.Init();
        builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterType<ContactRegistrationDbContext>().As<IContactRegistrationDbContext>().InstancePerLifetimeScope());        
        builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new RegisterRepositories()));        
        
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();        
        builder.Services.AddLogging();        
    }
}
