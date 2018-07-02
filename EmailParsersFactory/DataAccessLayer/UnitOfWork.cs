using Core.Interfaces.DataContext;
using Core.Interfaces.UnitOfWork;

namespace DataAccessLayer
{
    /// <summary>
    /// Unit of work class.
    /// </summary>
    /// <seealso cref="DataAccessLayer.UnitOfWorkBase" />
    /// <seealso cref="Core.Interfaces.UnitOfWork.IUnitOfWork" />
    public class UnitOfWork : UnitOfWorkBase, IUnitOfWork
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="dataContext">The data context.</param>
        public UnitOfWork(IDataContext dataContext)
            : base(dataContext)
        {
        }
    }
}
