
namespace ContactRegistration.Application.Profiles;

internal class ContactProfile : Profile
{
    public ContactProfile()
    {
        CreateMap<Contact, ContactModel>()
         .ReverseMap();
    }
}
