
namespace ContactRegistration.Application.IRepositories;

public interface IGenericRepository<T> where T : class
{
    /// <summary>
    /// The Table.
    /// </summary>
    /// <param name="predicate">The predicate<see cref="Expression{Func{T, bool}}"/>.</param>
    /// <returns>The <see cref="Task{IQueryable{T}}"/>.</returns>
    Task<IQueryable<T>> Table(Expression<Func<T, bool>> predicate);

    /// <summary>
    /// The ToListAsync.
    /// </summary>
    /// <returns>The <see cref="Task{List{T}}"/>.</returns>
    Task<List<T>> ToListAsync();

    /// <summary>
    /// The GetById.
    /// </summary>
    /// <param name="id">The id<see cref="object"/>.</param>
    /// <returns>The <see cref="Task{T?}"/>.</returns>
    Task<T?> GetById(object id);

    /// <summary>
    /// The Insert.
    /// </summary>
    /// <param name="entity">The entity<see cref="T"/>.</param>
    /// <returns>The <see cref="Task"/>.</returns>
    Task<T> Insert(T entity);

    /// <summary>
    /// The Update.
    /// </summary>
    /// <param name="entity">The entity<see cref="T"/>.</param>
    /// <returns>The <see cref="Task"/>.</returns>
    Task<T> Update(T entity);

    /// <summary>
    /// The Delete.
    /// </summary>
    /// <param name="entity">The entity<see cref="T"/>.</param>
    /// <returns>The <see cref="Task"/>.</returns>
    Task Delete(T entity);

    /// <summary>
    /// Deletes the specified identifier.
    /// </summary>
    /// <param name="id">The identifier.</param>
    /// <returns>The <see cref="Task"/>.</returns>
    Task<T?> Delete(object id);

    /// <summary>
    /// The SaveChangesAsync.
    /// </summary>
    /// <returns>The <see cref="Task{int}"/>.</returns>
    Task<int> SaveChangesAsync();
}