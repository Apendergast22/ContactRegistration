
namespace ContactRegistration.Application.Features.ContactRegistration.Handlers.Queries;

public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, DeleteContactResponse>
{
    public DeleteContactCommandHandler(
        IHttpContextAccessor context,
        ILogger<DeleteContactCommandHandler> logger,
        IMapper mapper,
        IContactRepository contactRepository)
    {
        Context = context;
        Logger = logger;
        Mapper = mapper;
        ContactRepository = contactRepository;
    }

    public readonly IHttpContextAccessor Context;
    public readonly ILogger<DeleteContactCommandHandler> Logger;
    public readonly IMapper Mapper;
    public readonly IContactRepository ContactRepository;

    public async Task<DeleteContactResponse> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        this.Logger.LogInformation($"Executed {nameof(DeleteContactCommandHandler)}");

        DeleteContactResponse response = new();
        response.MessageSummary!.StatusCode = StatusCodes.Status200OK;
        response.MessageSummary.TraceId = Context.HttpContext!.TraceIdentifier;
        
        var user = await ContactRepository.Delete(request.id);
        if (user is not null)
        {
            response.MessageSummary.Add(ContactResponseMessages.Instance.DeletedSuccessfully);
        }
        else
        {
            response.MessageSummary!.StatusCode = StatusCodes.Status404NotFound;            
        }

        return response;
    }
}
