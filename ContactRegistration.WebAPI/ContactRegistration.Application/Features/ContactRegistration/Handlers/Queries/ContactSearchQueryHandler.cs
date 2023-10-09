
namespace ContactRegistration.Application.Features.ContactRegistration.Handlers.Queries;

public class ContactSearchQueryHandler : IRequestHandler<ContactSearchQuery, ContactSearchResponse>
{
    public ContactSearchQueryHandler(
        IHttpContextAccessor context,
        ILogger<ContactSearchQueryHandler> logger,
        IMapper mapper,
        IContactRepository contactRepository)
    {
        Context = context;
        Logger = logger;
        Mapper = mapper;
        ContactRepository = contactRepository;
    }

    public readonly IHttpContextAccessor Context;
    public readonly ILogger<ContactSearchQueryHandler> Logger;
    public readonly IMapper Mapper;
    public readonly IContactRepository ContactRepository;

    public async Task<ContactSearchResponse> Handle(ContactSearchQuery request, CancellationToken cancellationToken)
    {
        this.Logger.LogInformation($"Executed {nameof(ContactSearchQueryHandler)}");

        ContactSearchResponse response = new();
        response.MessageSummary!.StatusCode = StatusCodes.Status200OK;
        response.MessageSummary.TraceId = Context.HttpContext!.TraceIdentifier;

        var users = await ContactRepository.Search(request.contactSearch.Name, request.contactSearch.FromDate, request.contactSearch.ToDate);
        if (users is null || !users.Any())
        {
            response.MessageSummary!.StatusCode = StatusCodes.Status404NotFound;
        }

        response.ContactModel = Mapper.Map<List<ContactModel>>(users);
        return response;
    }
}
