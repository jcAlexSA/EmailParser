using System.Data.Entity;
using Core.Interfaces.Repositories;
using Core.Interfaces.UnitOfWork;

namespace DataAccessLayer.Repositories
{
    /// <summary>
    /// Base class for repositories.
    /// </summary>
    /// <typeparam name="T">Type of entity.</typeparam>
    /// <seealso cref="Core.Interfaces.Repositories.IBaseRepository{T}" />
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseRepository{T}"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public BaseRepository(IUnitOfWork unitOfWork)
        {
            this.DataContext = unitOfWork.DataContext as DbContext;
        }

        /// <summary>
        /// Gets the data context.
        /// </summary>
        /// <value>
        /// The data context.
        /// </value>
        protected DbContext DataContext
        {
            get;
            private set;
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public virtual void Add(T entity)
        {
            this.DataContext.Set<T>().Add(entity);
        }
    }
}
