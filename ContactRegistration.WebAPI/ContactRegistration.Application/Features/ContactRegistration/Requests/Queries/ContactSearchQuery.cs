
namespace ContactRegistration.Application.Features.ContactRegistration.Requests.Queries;

public class ContactSearchQuery : BaseRequest, IRequest<ContactSearchResponse>
{    
    internal readonly ContactSearch contactSearch;

    public ContactSearchQuery(ContactSearch contactSearch)
    {
        this.contactSearch = contactSearch;
    }        
}
