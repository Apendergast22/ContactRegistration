
namespace ContactRegistration.Infrastructure.Repositories;

internal class ContactRepository : GenericRepository<Contact>, IContactRepository
{
    public ContactRepository(IContactRegistrationDbContext context) : base(context)
    {

    }
    public async Task<Contact?> GetById(long id)
    {
        return await this.Entities
            .Include(x => x.Emails)
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Contact>> Search(string? name, DateOnly? fromDate, DateOnly? toDate)
    {
        return await this.Entities
            .Include(x => x.Emails)
            .Where(a =>
            (string.IsNullOrWhiteSpace(name) || a.Name!.Contains(name)) &&
            (fromDate == null || a.BirthDate >= fromDate) &&
            (toDate == null || a.BirthDate <= toDate))
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<Contact?> Delete(long id)
    {
        var entity = await this.Entities
            .Include(x => x.Emails)
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();

        if (entity is not null)
        {            
            this.Entities.Entry(entity).State = EntityState.Deleted;
            await this.SaveChangesAsync();
            return entity;
        }

        return null;        
    }
}
