namespace Core.Interfaces.Configurations
{
    /// <summary>
    /// Interface to implementing target directory to download emails.
    /// </summary>
    public interface IDirectoryDowloadConfiguration
    {
        /// <summary>
        /// Gets the directory where emails downloaded.
        /// </summary>
        /// <value>
        /// The directory.
        /// </value>
        string Directory { get; }
    }
}
