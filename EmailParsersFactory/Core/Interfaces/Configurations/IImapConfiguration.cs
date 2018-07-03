namespace Core.Interfaces.Configurations
{
    /// <summary>
    /// Credentials for imap connection.
    /// </summary>
    public interface IImapConfiguration
    {
        /// <summary>
        /// Gets the login.
        /// </summary>
        /// <value>
        /// The login.
        /// </value>
        string Login { get; }

        /// <summary>
        /// Gets the password.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        string Password { get; }
    }
}
