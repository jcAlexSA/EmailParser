using System;
using System.IO;
using Autofac;
using Core.Interfaces;
using Core.Interfaces.Configurations;
using Core.Interfaces.Managers;
using EmailParsersFactory.Managers;
using EmailReader.Infrastructure;

namespace EmailParsersFactory.Tasks
{
    /// <summary>
    /// Task for download the emails.
    /// </summary>
    /// <seealso cref="Core.Interfaces.ITask" />
    public class EmailDownloadTask : ITask
    {
        /// <summary>
        /// Executes the downloading task.
        /// </summary>
        public void Execute()
        {
            IContainer container = AutofacConfig.Container;

            var articlesManager = container.Resolve<IArticlesManager>();

            string pathToDownload = container.Resolve<IDirectoryDowloadConfiguration>().Directory;
            if (!Directory.Exists(pathToDownload))
            {
                Directory.CreateDirectory(pathToDownload);
            }

            // Download emails.
            try
            {
                var emailsDownloader = new EmailsDownloader(container.Resolve<IImapConfiguration>());
                emailsDownloader.Download(pathToDownload);
            }
            catch (Exception ex)
            {
                var log = NLog.LogManager.GetLogger("database");
                log.Fatal(ex, ex.Message);
            }
        }
    }
}
