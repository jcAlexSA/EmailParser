using Core.Interfaces.UnitOfWork;

namespace EmailParsersFactory.Managers
{
    /// <summary>
    /// Base class for managers.
    /// </summary>
    public abstract class ManagerBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ManagerBase"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public ManagerBase(IUnitOfWork unitOfWork)
        {
            this.UnitOfWork = unitOfWork;
        }

        /// <summary>
        /// Gets the unit of work.
        /// </summary>
        /// <value>
        /// The unit of work.
        /// </value>
        protected IUnitOfWork UnitOfWork { get; private set; }
    }
}
