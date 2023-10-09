
namespace ContactRegistration.Application.Features.ContactRegistration.Handlers.Queries;

public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, UpdateContactResponse>
{
    public UpdateContactCommandHandler(
        IHttpContextAccessor context,
        ILogger<UpdateContactCommandHandler> logger,
        IMapper mapper,
        IContactRepository contactRepository)
    {
        Context = context;
        Logger = logger;
        Mapper = mapper;
        ContactRepository = contactRepository;
    }

    public readonly IHttpContextAccessor Context;
    public readonly ILogger<UpdateContactCommandHandler> Logger;
    public readonly IMapper Mapper;
    public readonly IContactRepository ContactRepository;

    public async Task<UpdateContactResponse> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        this.Logger.LogInformation($"Executed {nameof(UpdateContactCommandHandler)}");

        UpdateContactResponse response = new();
        response.MessageSummary!.StatusCode = StatusCodes.Status200OK;
        response.MessageSummary.TraceId = Context.HttpContext!.TraceIdentifier;

        var contact = Mapper.Map<Contact>(request.contact);

        var user = await ContactRepository.Update(contact);
        if (user is not null)
        {
            response.MessageSummary.Add(ContactResponseMessages.Instance.CreatedSuccessfully);
        }

        return response;
    }
}
