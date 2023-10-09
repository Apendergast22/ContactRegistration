
namespace ContactRegistration.Infrastructure.Repositories;

/// <summary>
/// Defines the <see cref="GenericRepository{T}" />.
/// </summary>
/// <typeparam name="T">.</typeparam>

public class GenericRepository<T> : IGenericRepository<T>
    where T : class
{
    /// <summary>
    /// Defines the Entities.
    /// </summary>
    protected readonly DbSet<T> Entities;

    /// <summary>
    /// Defines the context.
    /// </summary>
    private readonly IContactRegistrationDbContext context;

    /// <summary>
    /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
    /// </summary>
    /// <param name="context">The context<see cref="IAuthenticationDbContext"/>.</param>
    public GenericRepository(IContactRegistrationDbContext context)
    {
        this.context = context;
        this.Entities = context.Set<T>();
    }

    /// <summary>
    /// The Table.
    /// </summary>
    /// <param name="predicate">The predicate<see cref="Expression{Func{T, bool}}"/>.</param>
    /// <returns>The <see cref="Task{IQueryable{T}}"/>.</returns>
    public Task<IQueryable<T>> Table(Expression<Func<T, bool>> predicate) => Task.FromResult(this.Entities.Where(predicate).AsQueryable());

    /// <summary>
    /// The ToListAsync.
    /// </summary>
    /// <returns>The <see cref="Task{List{T}}"/>.</returns>
    public async Task<List<T>> ToListAsync() => await this.Entities.ToListAsync();

    /// <summary>
    /// The GetById.
    /// </summary>
    /// <param name="id">The id<see cref="object"/>.</param>
    /// <returns>The <see cref="Task{T?}"/>.</returns>
    public async Task<T?> GetById(object id) => await Entities.FindAsync(id);

    /// <summary>
    /// The Insert.
    /// </summary>
    /// <param name="entity">The entity<see cref="T"/>.</param>
    /// <returns>The <see cref="Task"/>.</returns>
    public async Task<T> Insert(T entity)
    {
        if (entity is not null)
        {
            await this.Entities.AddAsync(entity);
            await this.SaveChangesAsync();
            return entity;
        }

        throw new ArgumentNullException(Convert.ToString(nameof(T)));
    }


    /// <summary>
    /// The SaveChangesAsync.
    /// </summary>
    /// <returns>The <see cref="Task{int}"/>.</returns>
    public async Task<int> SaveChangesAsync() => await this.context.SaveChangesAsync();

    /// <summary>
    /// The Update.
    /// </summary>
    /// <param name="entity">The entity<see cref="T"/>.</param>
    /// <returns>The <see cref="Task"/>.</returns>
    public async Task<T> Update(T entity)
    {
        if (entity is not null)
        {
            this.context.Entry(entity).State = EntityState.Modified;
            await this.SaveChangesAsync();
            return entity;
        }

        throw new ArgumentNullException(nameof(T).ToString());
    }

    /// <summary>
    /// The Delete.
    /// </summary>
    /// <param name="entity">The entity<see cref="T"/>.</param>
    /// <returns>The <see cref="Task"/>.</returns>
    public async Task Delete(T entity)
    {
        if (entity is not null)
        {
            this.Entities.Attach(entity);
            this.context.Entry(entity).State = EntityState.Deleted;
            await this.SaveChangesAsync();
        }

        throw new ArgumentNullException(nameof(T).ToString());
    }

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>The <see cref="Task"/>.</returns>
    public async Task<T?> Delete(object id)
    {
        var entity = GetById(id);

        if (entity is not null && entity.Result is not null)
        {
            this.context.Entry(entity.Result).State = EntityState.Deleted;
            await this.SaveChangesAsync();
        }

        return null;        
    }
}

