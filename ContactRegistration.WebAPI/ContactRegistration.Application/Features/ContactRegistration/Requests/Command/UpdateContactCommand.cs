
namespace ContactRegistration.Application.Features.ContactRegistration.Requests.Queries;

public class UpdateContactCommand : BaseRequest, IRequest<UpdateContactResponse>
{
    internal readonly ContactModel contact;
    public UpdateContactCommand(ContactModel contact)
    {
        this.contact = contact;
    }    
}
