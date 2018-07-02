using System;
using System.IO;
using Autofac;
using Core.Interfaces;
using Core.Interfaces.Managers;
using EmailParsersFactory.Managers;
using EmailReader.Infrastructure;

namespace EmailParsersFactory.Tasks
{
    public class EmailDownloadTask : ITask
    {
        private string login;
        private string password;

        public EmailDownloadTask(string login, string password)
        {
            this.login = login;
            this.password = password;
        }

        public void Execute()
        {
            IContainer container = AutofacConfig.Container;

            var articlesManager = container.Resolve<IArticlesManager>();

            string pathToDownload = string.Concat(Environment.CurrentDirectory, @"\Emails\");
            if (!Directory.Exists(pathToDownload))
            {
                Directory.CreateDirectory(pathToDownload);
            }

            //Download emails.
            var emailsDownloader = new EmailsDownloader(login, password);
            emailsDownloader.Download(pathToDownload);
        }
    }
}
