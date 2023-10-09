
namespace ContactRegistration.Infrastructure.DataContext;
public class ContactRegistrationDbContext : DbContext, IContactRegistrationDbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ContactRegistrationDbContext"/> class.
    /// </summary>
    /// <param name="options">The options<see cref="DbContextOptions{ContactRegistrationDbContext}"/>.</param>
    public ContactRegistrationDbContext(DbContextOptions<ContactRegistrationDbContext> options)
    : base(options)
    {
    }

    /// <summary>
    /// Gets the Database.
    /// </summary>
    DatabaseFacade Database => this.Database;

    /// <summary>
    /// The Set.
    /// </summary>
    /// <typeparam name="T">.</typeparam>
    /// <returns>The <see cref="DbSet{T}"/>.</returns>
    public new DbSet<T> Set<T>() where T : class
    {
        return base.Set<T>();
    }

    /// <summary>
    /// The Update.
    /// </summary>
    /// <param name="entity">The entity<see cref="object"/>.</param>
    /// <returns>The <see cref="Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry"/>.</returns>
    public override Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry Update(object entity)
    {
        this.ChangeTracker.DetectChanges();
        return base.Update(entity);
    }

    /// <summary>
    /// The SaveChangesAsync.
    /// </summary>
    /// <returns>The <see cref="Task{int}"/>.</returns>
    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    /// <summary>
    /// The OnModelCreating.
    /// </summary>
    /// <param name="modelBuilder">The modelBuilder<see cref="ModelBuilder"/>.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}