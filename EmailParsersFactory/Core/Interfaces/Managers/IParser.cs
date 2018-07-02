using Core.Models.Dtos;

namespace Core.Interfaces
{
    /// <summary>
    /// Interface to parsers of aggragations news.
    /// </summary>
    public interface IParser
    {
        /// <summary>
        /// Parses the specified message.
        /// </summary>
        /// <param name="subject">The subject of message.</param>
        /// <param name="body">The body of message.</param>
        /// <returns>Article DTO.</returns>
        ArticleDto Parse(string subject, string body);
    }
}
