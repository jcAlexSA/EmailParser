using Core.Interfaces.Managers;
using Core.Interfaces.Repositories;
using Core.Interfaces.UnitOfWork;
using Core.Models;

namespace EmailParsersFactory.Managers
{
    /// <summary>
    /// Articles manager to working with DB.
    /// </summary>
    /// <seealso cref="EmailParsersFactory.Managers.ManagerBase" />
    /// <seealso cref="Core.Interfaces.Managers.IArticlesManager" />
    public class ArticlesManager : ManagerBase, IArticlesManager
    {
        /// <summary>
        /// The articles repository.
        /// </summary>
        private IArticlesRepository articlesRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="ArticlesManager"/> class.
        /// </summary>
        /// <param name="ar">Articles repository.</param>
        /// <param name="unitOfWork">The unit of work.</param>
        public ArticlesManager(IArticlesRepository ar, IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.articlesRepository = ar;
        }

        /// <summary>
        /// Adds the specified article to repository.
        /// </summary>
        /// <param name="article">The article.</param>
        public void Add(Article article)
        {
            this.articlesRepository.Add(article);

            this.UnitOfWork.Save();
        }
    }
}
