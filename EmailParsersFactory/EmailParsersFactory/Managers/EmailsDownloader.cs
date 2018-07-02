using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
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
        /// The credential for imap connection.
        /// </summary>
        private readonly NetworkCredential credential;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailsDownloader"/> class.
        /// </summary>
        /// <param name="credential">The credential.</param>
        public EmailsDownloader(NetworkCredential credential)
        {
            this.credential = credential;
        }

        /// <summary>
        /// Downloads the email to specify directory.
        /// </summary>
        /// <param name="directoryToDownload">The directory where download emails.</param>
        public void Download(string directoryToDownload)
        {
            using (var client = new ImapClient())
            {
                NetworkCredential credentials = this.credential;
                Uri uri = new Uri("imaps://imap.gmail.com");

                client.Connect(uri);
                client.Authenticate(credentials);

                IMailFolder folder = client.GetFolder("[Gmail]/All Mail");
                folder.Open(FolderAccess.ReadWrite);

                string from = null;
                string emailFolder = null;
                string settingMessageLabel = null;

                var uniqueIdPromotions = folder.Search(SearchQuery.HasGMailLabel("Promotions"));
                var uniqueIdInbox = folder.Search(SearchQuery.HasGMailLabel("Inbox"));
                var commonId = uniqueIdInbox.Intersect(uniqueIdPromotions).ToList();    // Get commond ids

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

                    if (settingMessageLabel != null)
                    {
                        folder.SetLabels(
                            id,
                            new System.Collections.Generic.List<string> { settingMessageLabel },
                            false);
                    }

                    using (StreamWriter streamWriterReader = new StreamWriter(
                        File.Create(string.Concat(directoryToDownload, emailFolder, GetValidFileName(id, content.Subject)))))
                    {
                        WriteMessageToTheFile(content, streamWriterReader, id);
                    }
                }

                client.Disconnect(true);
                Console.WriteLine("Message Count: {0} ", commonId.Count);
            }
        }

        /// <summary>
        /// Writes the message to the file.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <param name="sw">The stream writer.</param>
        /// <param name="id">The identifier of email.</param>
        private static void WriteMessageToTheFile(MimeKit.MimeMessage content, StreamWriter sw, UniqueId id)
        {
            sw.WriteLine(content.Subject);
            sw.WriteLine(content.From);
            sw.WriteLine(id);
            sw.WriteLine(content.HtmlBody);
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
