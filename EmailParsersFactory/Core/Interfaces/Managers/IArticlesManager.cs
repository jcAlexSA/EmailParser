using Core.Models;

namespace Core.Interfaces.Managers
{
    /// <summary>
    /// Interface for articles manager.
    /// </summary>
    public interface IArticlesManager
    {
        /// <summary>
        /// Adds the specified article.
        /// </summary>
        /// <param name="article">The article.</param>
        void Add(Article article);
    }
}
