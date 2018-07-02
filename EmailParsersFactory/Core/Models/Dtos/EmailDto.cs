namespace Core.Models.Dtos
{
    /// <summary>
    /// Dto to read files.
    /// </summary>
    public class EmailDto
    {
        /// <summary>
        /// Gets or sets sender.
        /// </summary>
        /// <value>
        /// Mail from.
        /// </value>
        public string From { get; set; }

        /// <summary>
        /// Gets or sets the subject message.
        /// </summary>
        /// <value>
        /// The subject of message.
        /// </value>
        public string Subject { get; set; }

        /// <summary>
        /// Gets or sets the message identifier from imap.
        /// </summary>
        /// <value>
        /// The message identifier from imap.
        /// </value>
        public int MessageId { get; set; }

        /// <summary>
        /// Gets or sets the body of message.
        /// </summary>
        /// <value>
        /// The body of email.
        /// </value>
        public string Body { get; set; }
    }
}
