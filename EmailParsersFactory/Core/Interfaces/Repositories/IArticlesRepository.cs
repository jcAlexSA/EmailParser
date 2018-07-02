using Core.Models;

namespace Core.Interfaces.Repositories
{
    /// <summary>
    /// Interface for articles repository.
    /// </summary>
    /// <seealso cref="Core.Interfaces.Repositories.IBaseRepository{Core.Models.Article}" />
    public interface IArticlesRepository : IBaseRepository<Article>
    {
    }
}
