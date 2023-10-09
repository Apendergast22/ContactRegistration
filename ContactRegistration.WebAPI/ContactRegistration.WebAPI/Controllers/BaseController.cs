
namespace ContactRegistration.WebAPI.Controllers;

/// <summary>
/// Defines the <see cref="BaseController{T}" />.
/// </summary>
/// <typeparam name="T"><see cref="BaseController{T}"/></typeparam>
public class BaseController<T> : ControllerBase where T : BaseController<T>
{
    /// <summary>
    /// Defines the mediator.
    /// </summary>
    protected readonly IMediator mediator;

    /// <summary>
    /// Defines the logger.
    /// </summary>
    protected readonly ILogger<T> logger;

    /// <summary>
    /// Defines the httpContextAccessor.
    /// </summary>
    protected readonly IHttpContextAccessor httpContextAccessor;

    /// <summary>
    /// Defines the IMapper.
    /// </summary>
    protected readonly IMapper mapper;

    /// <summary>
    /// The cancellation token
    /// </summary>
    protected CancellationToken cancellationToken = new();

    /// <summary>
    /// Defines the Base Controller
    /// </summary>
    /// <param name="mediator"><see cref="IMediator"/></param>
    /// <param name="logger"><see cref="ILogger"/></param>
    /// <param name="httpContextAccessor"><see cref="HttpContextAccessor"/></param>
    /// <param name="mapper"><see cref="IMapper"/></param>
    public BaseController(IMediator mediator, ILogger<T> logger, IHttpContextAccessor httpContextAccessor, IMapper mapper)
    {
        this.mediator = mediator;
        this.logger = logger;
        this.httpContextAccessor = httpContextAccessor;
        this.mapper = mapper;
    }
}