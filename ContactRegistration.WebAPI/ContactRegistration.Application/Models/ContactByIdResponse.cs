
namespace ContactRegistration.Application.Models;

public class ContactByIdResponse : BaseResponse
{
    public ContactByIdResponse()
    {        
        this.MessageSummary = new();
    }

    public ContactModel? ContactModel { get; set; }
}
