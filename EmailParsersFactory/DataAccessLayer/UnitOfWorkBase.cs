using System;
using System.Data.Entity;
using Core.Interfaces.DataContext;
using Core.Interfaces.UnitOfWork;

namespace DataAccessLayer
{
    /// <summary>
    /// Base unit of work realization.
    /// </summary>
    /// <seealso cref="Core.Interfaces.UnitOfWork.IUnitOfWork" />
    public class UnitOfWorkBase : IUnitOfWork
    {
        /// <summary>
        /// The database context.
        /// </summary>
        private DbContext databaseContext;

        /// <summary>
        /// Is disposed instance.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWorkBase"/> class.
        /// </summary>
        /// <param name="dataContext">The data context.</param>
        public UnitOfWorkBase(IDataContext dataContext)
        {
            this.databaseContext = dataContext as DbContext;
        }

        /// <summary>
        /// Gets the data context.
        /// </summary>
        /// <value>
        /// The data context.
        /// </value>
        public IDataContext DataContext
        {
            get
            {
                return (IDataContext)this.databaseContext;
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing,
        /// or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged
        /// resources; <c>false</c> to release only unmanaged resources.</param>
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    this.databaseContext.Dispose();
                }

                this.disposed = true;
            }
        }

        /// <summary>
        /// Saves changes in the database context.
        /// </summary>
        public void Save()
        {
            this.databaseContext.SaveChanges();
        }
    }
}
