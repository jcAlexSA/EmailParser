using System.IO;
using System.Reflection;
using Core.Interfaces;
using Core.Models.Dtos;
using EmailParser.Managers.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmailParser.Tests
{
    /// <summary>
    /// Class to provide tests for Tech Today aggregator.
    /// </summary>
    [TestClass]
    public class TechTodayUnitTests
    {
        /// <summary>
        /// The namespace of testing files.
        /// </summary>
        private readonly string namespaceTestFiles = "EmailParser.Tests.TestData.TechToday.";

        /// <summary>
        /// Parses the file 169 boost your music.
        /// </summary>
        [TestMethod]
        public void TechToday_169_BoostYourMusic()
        {
            // Arrange
            string fileName = "169_Boost Your Music with Tech Tips.html";

            ArticleDto articleDtoTemplate = new ArticleDto
            {
                Title = "Boost Your Music with Tech Tips",
                Link = "http://link.lifewire.com/click/13639644.159979/aHR0cHM6Ly93d3cubGlmZXdpcmUuY29tL3Nwb25zb3JlZC9tdXNpY2FsdHJhdmVsc3Rocm91Z2h0ZWNoP3V0bV9jYW1wYWlnbj1jb21wdXRlcnNsJnV0bV9tZWRpdW09ZW1haWwmdXRtX3NvdXJjZT1jbl9ubCZ1dG1fY29udGVudD0xMzYzOTY0NCZ1dG1fdGVybT0/5b2bb4ac639ec82cd4094eb9B968f1aad"
            };

            EmailDto emailDto = this.GetDtoFromTestFiles(fileName);

            // Act
            IParser parser = new TechTodayParser();
            ArticleDto articleDto = parser.Parse(emailDto.Subject, emailDto.Body);

            // Assert
            Assert.AreEqual(articleDtoTemplate.Title, articleDto.Title);
            Assert.AreEqual(articleDtoTemplate.Link, articleDto.Link);
        }

        /// <summary>
        /// Parses the file 158 protect your privacy.
        /// </summary>
        [TestMethod]
        public void TechToday_158_ProtectYourPrivacy()
        {
            // Arrange
            string fileName = "158_Protect Your Privacy by Locking Apps on Your iPhone.html";

            ArticleDto articleDtoTemplate = new ArticleDto
            {
                Title = "Protect Your Privacy by Locking Apps on Your iPhone",
                Link = "http://link.lifewire.com/click/13650063.92139/aHR0cHM6Ly93d3cubGlmZXdpcmUuY29tL2xvY2stYXBwcy1vbi1pcGhvbmUtNDE2NDg2ND91dG1fY2FtcGFpZ249Y29tcHV0ZXJzbCZ1dG1fbWVkaXVtPWVtYWlsJnV0bV9zb3VyY2U9Y25fbmwmdXRtX2NvbnRlbnQ9MTM2NTAwNjMmdXRtX3Rlcm09/5b2bb4ac639ec82cd4094eb9B3e48beec"
            };

            EmailDto emailDto = this.GetDtoFromTestFiles(fileName);

            // Act
            IParser parser = new TechTodayParser();
            ArticleDto articleDto = parser.Parse(emailDto.Subject, emailDto.Body);

            // Assert
            Assert.AreEqual(articleDtoTemplate.Title, articleDto.Title);
            Assert.AreEqual(articleDtoTemplate.Link, articleDto.Link);
        }

        /// <summary>
        /// Parses the file 152  9 android apps to make.
        /// </summary>
        [TestMethod]
        public void TechToday_152_9AndroidAppsToMake()
        {
            // Arrange
            string fileName = "152_9 Android Apps to Make Your Phone Run Faster.html";

            ArticleDto articleDtoTemplate = new ArticleDto
            {
                Title = "9 Android Apps to Make Your Phone Run Faster",
                Link = "http://link.lifewire.com/click/13650094.92107/aHR0cHM6Ly93d3cubGlmZXdpcmUuY29tL2Jlc3QtYW5kcm9pZC1ib29zdGVyLWFwcHMtNDE2NTUxMz91dG1fY2FtcGFpZ249Y29tcHV0ZXJzbCZ1dG1fbWVkaXVtPWVtYWlsJnV0bV9zb3VyY2U9Y25fbmwmdXRtX2NvbnRlbnQ9MTM2NTAwOTQmdXRtX3Rlcm09/5b2bb4ac639ec82cd4094eb9Bdefaf342"
            };

            EmailDto emailDto = this.GetDtoFromTestFiles(fileName);

            // Act
            IParser parser = new TechTodayParser();
            ArticleDto articleDto = parser.Parse(emailDto.Subject, emailDto.Body);

            // Assert
            Assert.AreEqual(articleDtoTemplate.Title, articleDto.Title);
            Assert.AreEqual(articleDtoTemplate.Link, articleDto.Link);
        }

        /// <summary>
        /// Parses the file 151 8 plugs to make your home.
        /// </summary>
        [TestMethod]
        public void TechToday_151_8PlugsToMakeYourHome()
        {
            // Arrange
            string fileName = "151_8 Plugs to Make Your Home a Little Smarter.html";

            ArticleDto articleDtoTemplate = new ArticleDto
            {
                Title = "8 Plugs to Make Your Home a Little Smarter",
                Link = "http://link.lifewire.com/click/13650146.91947/aHR0cHM6Ly93d3cubGlmZXdpcmUuY29tL2Jlc3Qtc21hcnQtcGx1Z3MtNDE2MzAwMT91dG1fY2FtcGFpZ249Y29tcHV0ZXJzbCZ1dG1fbWVkaXVtPWVtYWlsJnV0bV9zb3VyY2U9Y25fbmwmdXRtX2NvbnRlbnQ9MTM2NTAxNDYmdXRtX3Rlcm09/5b2bb4ac639ec82cd4094eb9Ba3d4474d"
            };

            EmailDto emailDto = this.GetDtoFromTestFiles(fileName);

            // Act
            IParser parser = new TechTodayParser();
            ArticleDto articleDto = parser.Parse(emailDto.Subject, emailDto.Body);

            // Assert
            Assert.AreEqual(articleDtoTemplate.Title, articleDto.Title);
            Assert.AreEqual(articleDtoTemplate.Link, articleDto.Link);
        }

        /// <summary>
        /// Parses the file 147 10 types of internet trolls.
        /// </summary>
        [TestMethod]
        public void TechToday_147_10TypesOfInternetTrolls()
        {
            // Arrange
            string fileName = "147_10 Types of Internet Trolls You’ll Meet Online.html";

            ArticleDto articleDtoTemplate = new ArticleDto
            {
                Title = "10 Types of Internet Trolls You’ll Meet Online",
                Link = "http://link.lifewire.com/click/13674363.91819/aHR0cHM6Ly93d3cubGlmZXdpcmUuY29tL3R5cGVzLW9mLWludGVybmV0LXRyb2xscy0zNDg1ODk0P3V0bV9jYW1wYWlnbj1jb21wdXRlcnNsJnV0bV9tZWRpdW09ZW1haWwmdXRtX3NvdXJjZT1jbl9ubCZ1dG1fY29udGVudD0xMzY3NDM2MyZ1dG1fdGVybT0/5b2bb4ac639ec82cd4094eb9B51b81171"
            };

            EmailDto emailDto = this.GetDtoFromTestFiles(fileName);

            // Act
            IParser parser = new TechTodayParser();
            ArticleDto articleDto = parser.Parse(emailDto.Subject, emailDto.Body);

            // Assert
            Assert.AreEqual(articleDtoTemplate.Title, articleDto.Title);
            Assert.AreEqual(articleDtoTemplate.Link, articleDto.Link);
        }

        /// <summary>
        /// Gets the email dto based on test file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>EmailDto based on file.</returns>
        private EmailDto GetDtoFromTestFiles(string fileName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(string.Concat(this.namespaceTestFiles, fileName));

            using (StreamReader sr = new StreamReader(stream))
            {
                EmailDto emailDto = new EmailDto
                {
                    Subject = sr.ReadLine(),
                    From = sr.ReadLine(),
                    MessageId = System.Convert.ToInt32(sr.ReadLine()),
                    Body = sr.ReadToEnd()
                };

                return emailDto;
            }
        }
    }
}
