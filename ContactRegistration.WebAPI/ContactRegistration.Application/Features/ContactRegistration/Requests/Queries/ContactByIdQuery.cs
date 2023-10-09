
namespace ContactRegistration.Application.Features.ContactRegistration.Requests.Queries;

public class ContactByIdQuery : BaseRequest, IRequest<ContactByIdResponse>
{
    internal readonly long id;
    public ContactByIdQuery(long id)
    {
        this.id = id;
    }    
}
