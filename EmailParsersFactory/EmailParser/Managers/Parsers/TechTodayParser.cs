using Core.Interfaces;
using Core.Models.Dtos;
using HtmlAgilityPack;

namespace EmailParser.Managers.Parsers
{
    /// <summary>
    /// Parser for letters from Tech Today Aggregator.
    /// </summary>
    /// <seealso cref="EmailParser.Intefaces.IParser" />
    public class TechTodayParser : IParser
    {
        /// <summary>
        /// Parses the Tech Today message.
        /// </summary>
        /// <param name="subject">The subject of message.</param>
        /// <param name="body">The body of message.</param>
        /// <returns>Article dto.</returns>
        public ArticleDto Parse(string subject, string body)
        {
            ArticleDto articleDto = new ArticleDto();

            var document = new HtmlDocument();
            document.LoadHtml(body);

            var message = document.DocumentNode.SelectSingleNode("//td[table[@class='column50']]");

            articleDto.Title = message.SelectSingleNode("//td[@class='h1m']/a").InnerHtml.ToString();
            articleDto.Link = message.SelectSingleNode("//td[@class='h1m']/a").Attributes["href"].Value;

            articleDto.Body = body;

            return articleDto;
        }
    }
}
