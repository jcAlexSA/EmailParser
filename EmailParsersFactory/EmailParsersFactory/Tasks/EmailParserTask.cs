using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Core.Interfaces;
using Core.Interfaces.Managers;
using Core.Models;
using Core.Models.Dtos;
using EmailParser.Managers.Factory;
using EmailParsersFactory.Infrastructure;
using EmailReader.Infrastructure;

namespace EmailParsersFactory.Tasks
{
    public class EmailParserTask : ITask
    {
        public void Execute()
        {
            IContainer container = AutofacConfig.Container;
            IArticlesManager articlesManager = container.Resolve<IArticlesManager>();

            string pathToFiles = string.Concat(Environment.CurrentDirectory, @"\Emails\");

            // Get downloaded emails.
            var files = Directory.GetFiles(pathToFiles, "*.*", SearchOption.AllDirectories);

            // Read emails and write content to DB.
            foreach (var file in files)
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    EmailDto emailDto = EmailDtoFileWorker.GetEmailDto(sr);

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
            }
        }
    }
}
