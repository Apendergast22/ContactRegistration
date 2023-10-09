
namespace ContactRegistration.Application.Features.ContactRegistration.Handlers.Queries;

public class AddContactCommandHandler : IRequestHandler<AddContactCommand, AddContactResponse>
{
    public AddContactCommandHandler(
        IHttpContextAccessor context,
        ILogger<AddContactCommandHandler> logger,
        IMapper mapper,
        IContactRepository contactRepository)
    {
        Context = context;
        Logger = logger;
        Mapper = mapper;
        ContactRepository = contactRepository;
    }

    public readonly IHttpContextAccessor Context;
    public readonly ILogger<AddContactCommandHandler> Logger;
    public readonly IMapper Mapper;
    public readonly IContactRepository ContactRepository;

    public async Task<AddContactResponse> Handle(AddContactCommand request, CancellationToken cancellationToken)
    {
        this.Logger.LogInformation($"Executed {nameof(AddContactCommandHandler)}");

        AddContactResponse response = new();
        response.MessageSummary!.StatusCode = StatusCodes.Status200OK;
        response.MessageSummary.TraceId = Context.HttpContext!.TraceIdentifier;

        var contact = Mapper.Map<Contact>(request.contact);

        var user = await ContactRepository.Insert(contact);
        if (user is not null)
        {
            response.MessageSummary.Add(ContactResponseMessages.Instance.CreatedSuccessfully);
        }

        return response;
    }
}
