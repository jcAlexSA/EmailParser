using System;
using System.IO;
using Autofac;
using Core.Interfaces;
using Core.Interfaces.Configurations;
using Core.Interfaces.Managers;
using Core.Models;
using Core.Models.Dtos;
using EmailParser.Managers.Factory;
using EmailParsersFactory.Infrastructure;
using EmailReader.Infrastructure;

namespace EmailParsersFactory.Tasks
{
    /// <summary>
    /// Task for parsing the emails.
    /// </summary>
    /// <seealso cref="Core.Interfaces.ITask" />
    public class EmailParserTask : ITask
    {
        /// <summary>
        /// Executes the parsing task.
        /// </summary>
        public void Execute()
        {
            IContainer container = AutofacConfig.Container;
            IArticlesManager articlesManager = container.Resolve<IArticlesManager>();

            string pathToFiles = container.Resolve<IDirectoryDowloadConfiguration>().Directory;

            // Get downloaded emails.
            var files = Directory.GetFiles(pathToFiles, "*.*", SearchOption.AllDirectories);

            // Read emails and write content to DB.
            foreach (var file in files)
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    EmailDto emailDto = EmailDtoFileWorker.GetEmailDto(sr);

                    try
                    {
                        // Parse email from Email Dto.
                        IParser parser = new ParserFactory().GetParser(emailDto, container);
                        if (parser == null)
                        {
                            continue;
                        }

                        ArticleDto articleDto = parser.Parse(emailDto.Subject, emailDto.Body);

                        // Write Article to DB.
                        Article article = Mapper.MapArticleDtoToArticle(articleDto);
                        article.EmailId = emailDto.MessageId;
                        articlesManager.Add(article);
                    }
                    catch (Exception ex)
                    {
                        var log = NLog.LogManager.GetLogger("database");
                        log.Fatal(ex, ex.Message);
                    }
                }
            }
        }
    }
}
