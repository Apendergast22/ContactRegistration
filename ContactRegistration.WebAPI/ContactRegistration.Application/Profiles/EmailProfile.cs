
namespace ContactRegistration.Application.Profiles;

internal class EmailProfile : Profile
{
    public EmailProfile()
    {
        CreateMap<Email, EmailModel>()
         .ReverseMap();
    }
}
