
using ContactRegistration.Application.Constants;
using ContactRegistration.Application.Models;
using MediatR;

namespace ContactRegistration.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContactController : BaseController<ContactController>
{
    public ContactController(IMediator mediator, ILogger<ContactController> logger, IHttpContextAccessor httpContextAccessor, IMapper mapper) 
        : base(mediator, logger, httpContextAccessor, mapper)
    {
    }
    
    [HttpPost(HttpVerbConstants.Search)]
    public async Task<IActionResult> Get([FromBody] ContactSearch request)
    {
        ContactSearchQuery searchRequest = new(request);
        var response = await mediator.Send(searchRequest);
        return StatusCode(response.MessageSummary!.StatusCode, response);
    }

    
    [HttpGet(HttpVerbConstants.ID)]
    public async Task<IActionResult> Get(long id)
    {
        try
        {
            ContactByIdQuery request = new(id);
            var response = await mediator.Send(request);
            return StatusCode(response.MessageSummary!.StatusCode, response);
        }
        catch (Exception ex)
        {

            throw;
        }        
    }

    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ContactModel request)
    {
        AddContactCommand addContactCommand  = new(request);
        var response = await mediator.Send(addContactCommand);
        return StatusCode(response.MessageSummary!.StatusCode, response);
    }

    
    [HttpPut]
    public async Task<IActionResult> Put([FromBody] ContactModel request)
    {
        UpdateContactCommand updateContactCommand = new(request);
        var response = await mediator.Send(updateContactCommand);
        return StatusCode(response.MessageSummary!.StatusCode, response);
    }

    
    [HttpDelete(HttpVerbConstants.ID)]
    public async Task<IActionResult> Delete(long id)
    {
        DeleteContactCommand request = new(id);
        var response = await mediator.Send(request);
        return StatusCode(response.MessageSummary!.StatusCode, response);
    }
}
