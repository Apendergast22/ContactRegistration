
namespace ContactRegistration.Application.Models;

public class ContactSearchResponse : BaseResponse
{
    public ContactSearchResponse()
    {        
        this.MessageSummary = new();
    }
    public List<ContactModel>? ContactModel { get; set; }
}
