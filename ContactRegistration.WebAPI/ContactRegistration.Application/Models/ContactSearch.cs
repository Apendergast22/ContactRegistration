
namespace ContactRegistration.Application.Models;

public class ContactSearch : BaseRequest
{
    public string? Name { get; set; }
    public DateOnly? FromDate { get; set; }
    public DateOnly? ToDate { get; set; }
}
