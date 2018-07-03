using Autofac;
using Core.Interfaces;

namespace EmailParsersFactory.Tasks.Factory
{
    /// <summary>
    /// Tasks factory.
    /// </summary>
    public class TaskFactory
    {
        /// <summary>
        /// Gets the task based on command using autofac resolver.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <param name="container">The container of autofac.</param>
        /// <returns>Target task.</returns>
        public ITask GetTask(string command, IContainer container)
        {
            try
            {
                return container.ResolveNamed<ITask>(command);
            }
            catch (Autofac.Core.Registration.ComponentNotRegisteredException)
            {
                return null;
            }
        }
    }
}
