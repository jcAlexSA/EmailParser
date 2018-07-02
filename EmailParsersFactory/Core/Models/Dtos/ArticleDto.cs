using System;

namespace Core.Models.Dtos
{
    /// <summary>
    /// Dto for news from CNBC Aggregator.
    /// </summary>
    public class ArticleDto
    {
        /// <summary>
        /// Gets or sets the title of article.
        /// </summary>
        /// <value>
        /// The title of article.
        /// </value>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets the link title.
        /// </summary>
        /// <value>
        /// The link of title.
        /// </value>
        public string Link { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date of article publich.
        /// </value>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the body of article.
        /// </summary>
        /// <value>
        /// The body of article.
        /// </value>
        public string Body { get; set; }

        /// <summary>
        /// Gets or sets the email identifier from imap.
        /// </summary>
        /// <value>
        /// The email identifier from imap.
        /// </value>
        public int EmailId { get; set; }
    }
}
