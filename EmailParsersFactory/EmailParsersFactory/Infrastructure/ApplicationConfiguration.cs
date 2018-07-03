using System.Configuration;
using Core.Interfaces.Configurations;

namespace EmailParsersFactory.Infrastructure
{
    /// <summary>
    /// Configuration of the application.
    /// </summary>
    /// <seealso cref="Core.Interfaces.IImapConfiguration" />
    public class ApplicationConfiguration : IImapConfiguration, IDirectoryDowloadConfiguration
    {
        /// <summary>
        /// Gets the login.
        /// </summary>
        /// <value>
        /// The login.
        /// </value>
        public string Login { get; } = ConfigurationManager.AppSettings["login"];

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string Password { get; } = ConfigurationManager.AppSettings["password"];

        /// <summary>
        /// Gets the directory to download emails.
        /// </summary>
        /// <value>
        /// The directory.
        /// </value>
        public string Directory { get; } = string.Concat(System.Environment.CurrentDirectory, @"\Emails\");
    }
}
