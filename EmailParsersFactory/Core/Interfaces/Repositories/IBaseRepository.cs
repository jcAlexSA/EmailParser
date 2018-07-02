namespace Core.Interfaces.Repositories
{
    /// <summary>
    /// Interface with base method to working with DB.
    /// </summary>
    /// <typeparam name="T">Type of entity.</typeparam>
    public interface IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        void Add(T entity);
    }
}
