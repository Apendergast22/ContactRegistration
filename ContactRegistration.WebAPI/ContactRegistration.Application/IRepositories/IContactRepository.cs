
namespace ContactRegistration.Application.IRepositories;

public interface IContactRepository : IGenericRepository<Contact>
{    
    Task<Contact?> GetById(long id);

    Task<List<Contact>> Search(string? name, DateOnly? fromDate, DateOnly? toDate);

    Task<Contact?> Delete(long id);    
}
