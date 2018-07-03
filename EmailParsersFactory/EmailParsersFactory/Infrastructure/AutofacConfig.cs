using System.Linq;
using System.Reflection;
using Autofac;
using Autofac.Core;
using Core.Interfaces;
using Core.Interfaces.DataContext;
using Core.Interfaces.Managers;
using Core.Interfaces.Repositories;
using Core.Interfaces.UnitOfWork;
using DataAccessLayer.Repositories;
using EmailParser.Managers.Parsers;
using EmailParsersFactory.Infrastructure;
using EmailParsersFactory.Managers;
using EmailParsersFactory.Tasks;

namespace EmailReader.Infrastructure
{
    /// <summary>
    /// Static autofac's configuration class.
    /// </summary>
    public static class AutofacConfig
    {
        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public static IContainer Container { get; private set; }

        /// <summary>
        /// Configurations of autofac.
        /// </summary>
        public static void Configuration()
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(typeof(BaseRepository<>).Assembly)
                                .Where(t => t.GetInterfaces()
                                    .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IBaseRepository<>))
                                    || typeof(IDataContext).IsAssignableFrom(t)
                                    || (typeof(IUnitOfWork).IsAssignableFrom(t) && !t.IsAbstract))
                                .AsImplementedInterfaces()
                                .InstancePerLifetimeScope();

            // Managers.
            builder.RegisterType<ArticlesManager>().As<IArticlesManager>();

            // Application Configuration.
            builder.RegisterType<ApplicationConfiguration>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            // Tasks.
            builder.RegisterType<EmailDownloadTask>().Named<ITask>("download");
            builder.RegisterType<EmailParserTask>().Named<ITask>("parse");

            // Parsers.
            builder.RegisterType<CnbcParser>().Named<IParser>("breakingnews@response.cnbc.com");
            builder.RegisterType<TechTodayParser>().Named<IParser>("newsletters@email.lifewire.com");

            Container = builder.Build();
        }
    }
}
