
namespace ContactRegistration.Application.IDataContext;

public interface IContactRegistrationDbContext
{
    /// <summary>
    /// Gets or sets the database set.
    /// </summary>
    /// <value>
    /// The database set.
    /// </value>
    DbSet<T> Set<T>() where T : class;

    /// <summary>
    /// Saves the changes asynchronous.
    /// </summary>
    /// <returns></returns>
    Task<int> SaveChangesAsync();

    /// <summary>
    /// Entries the specified entity.
    /// </summary>
    /// <param name="entity">The entity.</param>
    /// <returns></returns>
    EntityEntry Entry(object entity);

    /// <summary>
    /// Gets the database.
    /// </summary>
    /// <value>
    /// The database.
    /// </value>
    DatabaseFacade Database { get; }    
}
