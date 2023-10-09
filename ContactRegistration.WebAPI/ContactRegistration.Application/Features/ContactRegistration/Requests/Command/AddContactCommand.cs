
namespace ContactRegistration.Application.Features.ContactRegistration.Requests.Queries;

public class AddContactCommand : BaseRequest, IRequest<AddContactResponse>
{
    internal readonly ContactModel contact;
    public AddContactCommand(ContactModel contact)
    {
        this.contact = contact;
    }    
}
