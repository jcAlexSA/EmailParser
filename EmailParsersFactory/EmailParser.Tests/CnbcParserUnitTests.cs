using System.IO;
using System.Reflection;
using Core.Interfaces;
using Core.Models.Dtos;
using EmailParser.Managers.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmailParser.Tests
{
    /// <summary>
    /// Test class for CNBC parser.
    /// </summary>
    [TestClass]
    public class CnbcParserUnitTests
    {
        /// <summary>
        /// The namespace test files.
        /// </summary>
        private readonly string namespaceTestFiles = "EmailParser.Tests.TestData.CnbcBreakingNews.";

        /// <summary>
        /// Parses the file 13 white house announces parsed file to dto.
        /// </summary>
        [TestMethod]
        public void Cnbc_13_WhiteHouseAnnounces()
        {
            // Arrange
            string fileName = "13_White House announces plan to merge Education and Labor departments.html";

            ArticleDto articleDtoTemplate = new ArticleDto
            {
                Title = "White House announces plan to merge Education and Labor departments",
                Link = "http://link.cnbc.com/click/13641737.34942/aHR0cHM6Ly93d3cuY25iYy5jb20vMjAxOC8wNi8yMS93aGl0ZS1ob3VzZS1hbm5vdW5jZXMtcGxhbi10by1tZXJnZS1kZXBhcnRtZW50cy1vZi1lZHVjYXRpb24tYW5kLWxhYm9yLmh0bWw_X19zb3VyY2U9bmV3c2xldHRlciU3Q2JyZWFraW5nbmV3cw/5b2bb23d91d15c45dd5a3c77B4bccaeea",
            };

            EmailDto emailDto = this.GetDtoFromTestFiles(fileName);

            // Act
            IParser parser = new CnbcParser();
            ArticleDto articleDto = parser.Parse(emailDto.Subject, emailDto.Body);

            // Assert
            Assert.AreEqual(articleDtoTemplate.Title, articleDto.Title);
            Assert.AreEqual(articleDtoTemplate.Link, articleDto.Link);
        }

        /// <summary>
        /// Parses the file 14 tesla is enhancing parse file to dto.
        /// </summary>
        [TestMethod]
        public void Cnbc_14_TeslaIsEnhancing()
        {
            // Arrange
            string fileName = "14_Tesla is enhancing security at Gigafactory, says they got a call that ex-employee was threatening violence.html";

            ArticleDto articleDtoTemplate = new ArticleDto
            {
                Title = "Tesla is enhancing security at Gigafactory, says they got a call that ex-employee was threatening violence",
                Link = "http://link.cnbc.com/click/13641742.34942/aHR0cHM6Ly93d3cuY25iYy5jb20vMjAxOC8wNi8yMS90ZXNsYS1zYXlzLWl0LWdvdC1jYWxsLXRoYXQtZXgtZW1wbG95ZWUtbWFydGluLXRyaXBwLXRocmVhdGVuZWQtdmlvbGVuY2UuaHRtbD9fX3NvdXJjZT1uZXdzbGV0dGVyJTdDYnJlYWtpbmduZXdz/5b2bb23d91d15c45dd5a3c77Bcf4a39f9",
            };

            EmailDto emailDto = this.GetDtoFromTestFiles(fileName);

            // Act
            IParser parser = new CnbcParser();
            ArticleDto articleDto = parser.Parse(emailDto.Subject, emailDto.Body);

            // Assert
            Assert.AreEqual(articleDtoTemplate.Title, articleDto.Title);
            Assert.AreEqual(articleDtoTemplate.Link, articleDto.Link);
        }

        /// <summary>
        /// Parses the file 16 dow falls more than parse file to dto.
        /// </summary>
        [TestMethod]
        public void Cnbc_16_DowFallsMoreThan()
        {
            // Arrange
            string fileName = "16_Dow falls more than 200 points on lingering trade worries, heads for 8-day losing streak.html";

            ArticleDto articleDtoTemplate = new ArticleDto
            {
                Title = "Dow falls more than 200 points on lingering trade worries, heads for 8-day losing streak",
                Link = "http://link.cnbc.com/click/13644512.34974/aHR0cHM6Ly93d3cuY25iYy5jb20vMjAxOC8wNi8yMS91cy1zdG9jay1mdXR1cmVzLWRhdGEtdHJhZGUtb2lsLWFuZC1wb2xpdGljcy1pbi1mb2N1cy5odG1sP19fc291cmNlPW5ld3NsZXR0ZXIlN0NicmVha2luZ25ld3M/5b2bb23d91d15c45dd5a3c77Ba564bd6b"
            };

            EmailDto emailDto = this.GetDtoFromTestFiles(fileName);

            // Act
            IParser parser = new CnbcParser();
            ArticleDto articleDto = parser.Parse(emailDto.Subject, emailDto.Body);

            // Assert
            Assert.AreEqual(articleDtoTemplate.Title, articleDto.Title);
            Assert.AreEqual(articleDtoTemplate.Link, articleDto.Link);
        }

        /// <summary>
        /// Parses the file 17 dow drops about parse file to dto.
        /// </summary>
        [TestMethod]
        public void Cnbc_17_DowDropsAbout()
        {
            // Arrange
            string fileName = "17_Dow drops about 200 points on trade worries, extends losing streak to 8 days.html";

            ArticleDto articleDtoTemplate = new ArticleDto
            {
                Title = "Dow drops about 200 points on trade worries, extends losing streak to 8 days",
                Link = "http://link.cnbc.com/click/13644901.35006/aHR0cHM6Ly93d3cuY25iYy5jb20vMjAxOC8wNi8yMS91cy1zdG9jay1mdXR1cmVzLWRhdGEtdHJhZGUtb2lsLWFuZC1wb2xpdGljcy1pbi1mb2N1cy5odG1sP19fc291cmNlPW5ld3NsZXR0ZXIlN0NicmVha2luZ25ld3M/5b2bb23d91d15c45dd5a3c77Bc3fc098c",
            };

            EmailDto emailDto = this.GetDtoFromTestFiles(fileName);

            // Act
            IParser parser = new CnbcParser();
            ArticleDto articleDto = parser.Parse(emailDto.Subject, emailDto.Body);

            // Assert
            Assert.AreEqual(articleDtoTemplate.Title, articleDto.Title);
            Assert.AreEqual(articleDtoTemplate.Link, articleDto.Link);
        }

        /// <summary>
        /// Parses the file 19 the head of amazon parse file to dto.
        /// </summary>
        [TestMethod]
        public void Cnbc_19_TheHeadOfAmazon()
        {
            // Arrange
            string fileName = "19_The head of Amazon's marketplace has lost most of his authority amid internal shake-up.html";

            ArticleDto articleDtoTemplate = new ArticleDto
            {
                Title = "The head of Amazon's marketplace has lost most of his authority amid internal shake-up",
                Link = "http://link.cnbc.com/click/13646101.35070/aHR0cHM6Ly93d3cuY25iYy5jb20vMjAxOC8wNi8yMS9hbWF6b25zLW1hcmtldHBsYWNlLXZwLXBldGVyLWZhcmljeS1sb3NlLW1vc3QtcmVzcG9uc2liaWxpdGllcy5odG1sP19fc291cmNlPW5ld3NsZXR0ZXIlN0NicmVha2luZ25ld3M/5b2bb23d91d15c45dd5a3c77B0f01162f",
            };

            EmailDto emailDto = this.GetDtoFromTestFiles(fileName);

            // Act
            IParser parser = new CnbcParser();
            ArticleDto articleDto = parser.Parse(emailDto.Subject, emailDto.Body);

            // Assert
            Assert.AreEqual(articleDtoTemplate.Title, articleDto.Title);
            Assert.AreEqual(articleDtoTemplate.Link, articleDto.Link);
        }

        /// <summary>
        /// Parses the file 22 stocks making the biggest moves parse file to dto.
        /// </summary>
        [TestMethod]
        public void Cnbc_22_StocksMakingTheBiggestMoves()
        {
            // Arrange
            string fileName = "22_Stocks making the biggest moves premarket BB, MDT, URI, JPM, BAC & more.html";

            ArticleDto articleDtoTemplate = new ArticleDto
            {
                Title = "Stocks making the biggest moves premarket: BB, MDT, URI, JPM, BAC & more",
                Link = "http://link.cnbc.com/click/13650370.34910/aHR0cHM6Ly93d3cuY25iYy5jb20vMjAxOC8wNi8yMi9zdG9ja3MtbWFraW5nLXRoZS1iaWdnZXN0LW1vdmVzLXByZW1hcmtldC1iYi1tZHQtdXJpLWpwbS1iYWMtbW9yZS5odG1sP19fc291cmNlPW5ld3NsZXR0ZXIlN0NicmVha2luZ25ld3M/5b2bb23d91d15c45dd5a3c77Bcde5ad1b",
            };

            EmailDto emailDto = this.GetDtoFromTestFiles(fileName);

            // Act
            IParser parser = new CnbcParser();
            ArticleDto articleDto = parser.Parse(emailDto.Subject, emailDto.Body);

            // Assert
            Assert.AreEqual(articleDtoTemplate.Title, articleDto.Title);
            Assert.AreEqual(articleDtoTemplate.Link, articleDto.Link);
        }

        /// <summary>
        /// Parses the file 25 trump threatens20 tariff parse file to dto.
        /// </summary>
        [TestMethod]
        public void Cnbc_25_TrumpThreatens20Tariff()
        {
            // Arrange
            string fileName = "25_Trump threatens 20% tariff on all car imports from the EU.html";

            ArticleDto articleDtoTemplate = new ArticleDto
            {
                Title = "Trump threatens 20% tariff on all car imports from the EU",
                Link = "http://link.cnbc.com/click/13651890.11614/aHR0cHM6Ly93d3cuY25iYy5jb20vMjAxOC8wNi8yMi90cnVtcC10aHJlYXRlbnMtMjAtcGVyY2VudC10YXJpZmYtb24tYWxsLWNhci1pbXBvcnRzLWZyb20tdGhlLWV1Lmh0bWw_X19zb3VyY2U9bmV3c2xldHRlciU3Q2JyZWFraW5nbmV3cw/5b2bb23d91d15c45dd5a3c77Bb8969742",
            };

            EmailDto emailDto = this.GetDtoFromTestFiles(fileName);

            // Act
            IParser parser = new CnbcParser();
            ArticleDto articleDto = parser.Parse(emailDto.Subject, emailDto.Body);

            // Assert
            Assert.AreEqual(articleDtoTemplate.Title, articleDto.Title);
            Assert.AreEqual(articleDtoTemplate.Link, articleDto.Link);
        }

        /// <summary>
        /// Parses the file 34 dow jumps more that parse file to dto.
        /// </summary>
        [TestMethod]
        public void Cnbc_34_DowJumpsMoreThat()
        {
            // Arrange
            string fileName = "34_Dow jumps more than 100 points, snaps 8-day losing streak.html";

            ArticleDto articleDtoTemplate = new ArticleDto
            {
                Title = "Dow jumps more than 100 points, snaps 8-day losing streak",
                Link = "http://link.cnbc.com/click/13656858.16990/aHR0cHM6Ly93d3cuY25iYy5jb20vMjAxOC8wNi8yMi91cy1zdG9jay1mdXR1cmVzLWRvdy1kYXRhLW9pbC10cmFkZS1hbmQtcG9saXRpY3Mtb24tdGhlLWFnZW5kYS5odG1sP19fc291cmNlPW5ld3NsZXR0ZXIlN0NicmVha2luZ25ld3M/5b2bb23d91d15c45dd5a3c77Bb0a7498e",
            };

            EmailDto emailDto = this.GetDtoFromTestFiles(fileName);

            // Act
            IParser parser = new CnbcParser();
            ArticleDto articleDto = parser.Parse(emailDto.Subject, emailDto.Body);

            // Assert
            Assert.AreEqual(articleDtoTemplate.Title, articleDto.Title);
            Assert.AreEqual(articleDtoTemplate.Link, articleDto.Link);
        }

        /// <summary>
        /// Parses the file 45 majority of americans approve parse file to dto.
        /// </summary>
        [TestMethod]
        public void Cnbc_40_StocksMakingThe()
        {
            // Arrange
            string fileName = "40_Stocks making the biggest moves premarket HOG, NFLX, GE, MSFT, AMZN & more.html";

            ArticleDto articleDtoTemplate = new ArticleDto
            {
                Title = "Stocks making the biggest moves premarket: HOG, NFLX, GE, MSFT, AMZN & more",
                Link = "http://link.cnbc.com/click/13675956.17214/aHR0cHM6Ly93d3cuY25iYy5jb20vMjAxOC8wNi8yNS9lYXJseS1tb3ZlcnMtc3RvY2tzLXByZW1hcmtldC1ob2ctbmZseC1nZS1tc2Z0LWFtem4uaHRtbD9fX3NvdXJjZT1uZXdzbGV0dGVyJTdDYnJlYWtpbmduZXdz/5b2bb23d91d15c45dd5a3c77Ba7290b0a",
            };

            EmailDto emailDto = this.GetDtoFromTestFiles(fileName);

            // Act
            IParser parser = new CnbcParser();
            ArticleDto articleDto = parser.Parse(emailDto.Subject, emailDto.Body);

            // Assert
            Assert.AreEqual(articleDtoTemplate.Title, articleDto.Title);
            Assert.AreEqual(articleDtoTemplate.Link, articleDto.Link);
        }

        /// <summary>
        /// Gets the email dto based on test file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>EmailDto based on file content.</returns>
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
