
namespace ContactRegistration.WebAPI.Extentions;

public static class ConfigureFluentValidatorExtention
{
    public static void ConfigureFluentValidator(this IServiceCollection services)
    {
        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();
        services.AddValidatorsFromAssemblyContaining<ContactValidator>();
    }
}
