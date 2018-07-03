using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Core.Interfaces.Configurations;
using Core.Models.Dtos;
using EmailParsersFactory.Infrastructure;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Search;

namespace EmailParsersFactory.Managers
{
    /// <summary>
    /// Class to download emails.
    /// </summary>
    public class EmailsDownloader
    {
        /// <summary>
        /// The imap configuration.
        /// </summary>
        private readonly IImapConfiguration imapConfiguration;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailsDownloader"/> class.
        /// </summary>
        /// <param name="imapConfiguration">Configuration for imap processing.</param>
        public EmailsDownloader(IImapConfiguration imapConfiguration)
        {
            this.imapConfiguration = imapConfiguration;
        }

        /// <summary>
        /// Downloads the email to specify directory.
        /// </summary>
        /// <param name="directoryToDownload">The directory where download emails.</param>
        public void Download(string directoryToDownload)
        {
            using (var client = new ImapClient())
            {
                Uri uri = new Uri("imaps://imap.gmail.com");

                client.Connect(uri);
                client.Authenticate(this.imapConfiguration.Login, this.imapConfiguration.Password);

                IMailFolder folder = client.GetFolder("[Gmail]/All Mail");
                folder.Open(FolderAccess.ReadWrite);

                string from = null;
                string emailFolder = null;
                string settingMessageLabel = null;

                var uniqueIdPromotions = folder.Search(SearchQuery.HasGMailLabel("Promotions"));
                var uniqueIdInbox = folder.Search(SearchQuery.HasGMailLabel("Inbox"));
                var commonId = uniqueIdInbox.Intersect(uniqueIdPromotions).ToList();    // Get commond ids

                Task[] tasks = new Task[commonId.Count];
                int taskIterator = 0;

                foreach (var id in commonId)
                {
                    var content = folder.GetMessage(id);
                    from = content.From.ToString();

                    if (from.Contains("breakingnews@response.cnbc.com"))
                    {
                        emailFolder = "CNBC\\";               // Write to CNBC folder
                        settingMessageLabel = "Parsed/Cnbc_BreakingNews";
                    }
                    else if (from.Contains("newsletters@email.lifewire.com"))
                    {
                        emailFolder = "TechToday\\";          // Write to Tech Today News
                        settingMessageLabel = "Parsed/TechToday";
                    }
                    else
                    {
                        emailFolder = "OTHERS\\";             // Write to 'OTHERS' folder
                        settingMessageLabel = "UnknownStructure";
                    }

                    CreateDirectoryIfNotExist(directoryToDownload + emailFolder);

                    // if (settingMessageLabel != null)
                    // {
                    //    folder.SetLabels(
                    //        id,
                    //        new System.Collections.Generic.List<string> { settingMessageLabel },
                    //        false);
                    // }

                    tasks[taskIterator] = new Task(() =>
                    {
                        WriteToFileProcess(
                            id,
                            string.Concat(directoryToDownload, emailFolder, GetValidFileName(id, content.Subject)),
                            content);
                    });
                    tasks[taskIterator++].Start();
                }

                Task.WaitAll(tasks);

                client.Disconnect(true);
                Console.WriteLine("Message Count: {0} ", commonId.Count);
            }
        }

        /// <summary>
        /// Writes to file async process.
        /// </summary>
        /// <param name="id">The identifier of message.</param>
        /// <param name="file">The file where write message.</param>
        /// <param name="content">The content of message.</param>
        /// <returns>Completed task.</returns>
        private static Task WriteToFileProcess(UniqueId id, string file, MimeKit.MimeMessage content)
        {
            return Task.Run(async () =>
            {
                using (StreamWriter sw = new StreamWriter(File.Create(file)))
                {
                    var emailDto = new EmailDto
                    {
                        Subject = content.Subject,
                        From = content.From.ToString(),
                        MessageId = (int)id.Id,
                        Body = content.HtmlBody
                    };

                    await Task.Run(() => { EmailDtoFileWorker.WriteEmailDto(sw, emailDto); });
                }
            });
        }

        /// <summary>
        /// Checks if directory exist.
        /// </summary>
        /// <param name="checkingFolder">The checking forlder.</param>
        private static void CreateDirectoryIfNotExist(string checkingFolder)
        {
            if (!Directory.Exists(checkingFolder))
            {
                Directory.CreateDirectory(checkingFolder);
            }
        }

        /// <summary>
        /// Gets the valid name of file.
        /// </summary>
        /// <param name="id">The identifier of message, that will be file's starter symbols.</param>
        /// <param name="subject">The subject of message.</param>
        /// <returns>File name.</returns>
        private static string GetValidFileName(UniqueId id, string subject)
        {
            string regexSearch = new string(Path.GetInvalidFileNameChars());
            Regex regex = new Regex(string.Format("[{0}]", Regex.Escape(regexSearch)));

            return string.Format("{0}_{1}.html", id, regex.Replace(subject, string.Empty));
        }
    }
}
