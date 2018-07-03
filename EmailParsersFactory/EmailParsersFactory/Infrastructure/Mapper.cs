using System;
using Core.Models;
using Core.Models.Dtos;

namespace EmailParsersFactory.Infrastructure
{
    /// <summary>
    /// Mapper class.
    /// </summary>
    public class Mapper
    {
        /// <summary>
        /// Maps the article dto upon article.
        /// </summary>
        /// <param name="dto">The article dto.</param>
        /// <returns>Mapped article.</returns>
        public static Article MapArticleDtoToArticle(ArticleDto dto)
        {
            Article article = new Article
            {
                Link = dto.Link,
                Title = dto.Title,
                Date = dto.Date != default(DateTime) ? dto.Date : DateTime.Now
            };

            return article;
        }
    }
}
