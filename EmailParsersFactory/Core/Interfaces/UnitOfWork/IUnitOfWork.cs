using System;
using Core.Interfaces.DataContext;

namespace Core.Interfaces.UnitOfWork
{
    /// <summary>
    /// Unit of work interface.
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the data context.
        /// </summary>
        /// <value>
        /// The data context.
        /// </value>
        IDataContext DataContext { get; }

        /// <summary>
        /// Saves changes.
        /// </summary>
        void Save();
    }
}
