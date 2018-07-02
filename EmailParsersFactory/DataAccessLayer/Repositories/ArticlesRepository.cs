using Core.Interfaces.Repositories;
using Core.Interfaces.UnitOfWork;
using Core.Models;

namespace DataAccessLayer.Repositories
{
    /// <summary>
    /// Repository for articles.
    /// </summary>
    /// <seealso cref="DataAccessLayer.Repositories.BaseRepository{Core.Models.Article}" />
    /// <seealso cref="Core.Interfaces.Repositories.IArticlesRepository" />
    public class ArticlesRepository : BaseRepository<Article>, IArticlesRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ArticlesRepository"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work.</param>
        public ArticlesRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }
}
