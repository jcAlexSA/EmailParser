using Core.Interfaces;
using Core.Models.Dtos;
using HtmlAgilityPack;

namespace EmailParser.Managers.Parsers
{
    /// <summary>
    /// Parser model of CNBC news.
    /// </summary>
    /// <seealso cref="EmailReader.Intefaces.IParser" />
    public class CnbcParser : IParser
    {
        /// <summary>
        /// Parses the CNBC message.
        /// </summary>
        /// <param name="subject">The subject of message.</param>
        /// <param name="body">The body of message.</param>
        /// <returns>Article dto.</returns>
        public ArticleDto Parse(string subject, string body)
        {
            ArticleDto articleDto = new ArticleDto();

            var doc = new HtmlDocument();
            doc.LoadHtml(body);

            var message = doc.DocumentNode.SelectSingleNode("//table//table[2]//td[1]");

            articleDto.Title = message.SelectSingleNode("//a[@class='headline']").InnerHtml;
            articleDto.Link = message.SelectSingleNode("//a[@class='headline']").Attributes["href"].Value;

            // message.RemoveChild(message.SelectSingleNode("table[1]"));      // Remove header
            // message.RemoveChild(message.SelectSingleNode("br[1]"));
            // articleDto.Body = message.InnerHtml;                             // Write body.

            articleDto.Body = body;

            return articleDto;
        }
    }
}
