
namespace ContactRegistration.Application.Features.ContactRegistration.Handlers.Queries;

public class ContactByIdQueryHandler : IRequestHandler<ContactByIdQuery, ContactByIdResponse>
{
    public ContactByIdQueryHandler(
        IHttpContextAccessor context,
        ILogger<ContactByIdQueryHandler> logger,
        IMapper mapper,
        IContactRepository contactRepository)
    {
        Context = context;
        Logger = logger;
        Mapper = mapper;
        ContactRepository = contactRepository;        
    }

    public readonly IHttpContextAccessor Context;
    public readonly ILogger<ContactByIdQueryHandler> Logger;
    public readonly IMapper Mapper;
    public readonly IContactRepository ContactRepository;

    public async Task<ContactByIdResponse> Handle(ContactByIdQuery request, CancellationToken cancellationToken)
    {
        this.Logger.LogInformation($"Executed {nameof(ContactByIdQueryHandler)}");
            
        ContactByIdResponse response = new();
        response.MessageSummary!.StatusCode = StatusCodes.Status200OK;
        response.MessageSummary.TraceId = Context.HttpContext!.TraceIdentifier;
        
        var user = await ContactRepository.GetById(request.id);
        if (user is null)
        {
            response.MessageSummary!.StatusCode = StatusCodes.Status404NotFound;
        }

        response.ContactModel = Mapper.Map<ContactModel>(user);
        return response;
    }
}
