using Autofac;
using Core.Interfaces;
using EmailParser.Managers.Parsers;

namespace EmailParser.Infrastructure
{
    /// <summary>
    /// Static autofac's configuration class.
    /// </summary>
    public static class AutofacConfig
    {
        /// <summary>
        /// The container.
        /// </summary>
        private static IContainer container;

        /// <summary>
        /// Gets the container.
        /// </summary>
        /// <value>
        /// The container.
        /// </value>
        public static IContainer Container
        {
            get
            {
                return container;
            }
        }

        /// <summary>
        /// Configurations autofac.
        /// </summary>
        public static void Configuration()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<CnbcParser>().Named<IParser>("breakingnews@response.cnbc.com");
            builder.RegisterType<TechTodayParser>().Named<IParser>("newsletters@email.lifewire.com");

            container = builder.Build();
        }
    }
}
