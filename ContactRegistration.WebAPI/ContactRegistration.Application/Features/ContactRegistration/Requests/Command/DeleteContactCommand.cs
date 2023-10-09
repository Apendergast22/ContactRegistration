
namespace ContactRegistration.Application.Features.ContactRegistration.Requests.Queries;

public class DeleteContactCommand : BaseRequest, IRequest<DeleteContactResponse>
{
    internal readonly long id;
    public DeleteContactCommand(long id)
    {
        this.id = id;
    }    
}
