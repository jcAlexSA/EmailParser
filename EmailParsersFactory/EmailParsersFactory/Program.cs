using System;
using System.IO;
using System.Net;
using Autofac;
using Core.Interfaces;
using Core.Interfaces.Managers;
using Core.Models;
using Core.Models.Dtos;
using EmailParser.Managers.Factory;
using EmailParsersFactory.Managers;
using EmailReader.Infrastructure;

namespace EmailReader
{
    /// <summary>
    /// Main class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments of main method.</param>
        public static void Main(string[] args)
        {
            AutofacConfig.Configuration();
            IContainer container = AutofacConfig.Container;

            var articlesManager = container.Resolve<IArticlesManager>();

            var credential = new NetworkCredential("news.fake.aggregator@gmail.com", "fake.news");
            string pathToDownload = @"D:\Projects\EmailParsersFactory\EmailParsersFactory\bin\Debug\Emails\";

            // Download promotion's emails.
            var emailsDownloader = new EmailsDownloader(credential);
            emailsDownloader.Download(pathToDownload);

            // Get download emails.
            var files = Directory.GetFiles(pathToDownload, "*.*", SearchOption.AllDirectories);

            // Read emails and write content to DB.
            foreach (var file in files)
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    EmailDto emailDto = GetEmailDto(sr);

                    // Parse email from Email Dto.
                    IParser parser = new ParserFactory().GetParser(emailDto, container);
                    if (parser == null)
                    {
                        continue;
                    }

                    ArticleDto articleDto = parser.Parse(emailDto.Subject, emailDto.Body);

                    // Write Article to DB.
                    Article article = MapArticle(articleDto);
                    article.EmailId = emailDto.MessageId;
                    articlesManager.Add(article);
                }
            }

            Console.WriteLine("Exit");
            System.Threading.Thread.Sleep(5000);
        }

        /// <summary>
        /// Gets the email dto from stream reader.
        /// </summary>
        /// <param name="sr">The stream reader.</param>
        /// <returns>The email dto based on file content.</returns>
        private static EmailDto GetEmailDto(StreamReader sr)
        {
            return new EmailDto
            {
                Subject = sr.ReadLine(),
                From = sr.ReadLine(),
                MessageId = Convert.ToInt32(sr.ReadLine()),
                Body = sr.ReadToEnd()
            };
        }

        /// <summary>
        /// Maps the article dto upon article.
        /// </summary>
        /// <param name="dto">The article dto.</param>
        /// <returns>Mapped article.</returns>
        private static Article MapArticle(ArticleDto dto)
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
