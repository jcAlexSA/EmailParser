using System;
using System.IO;
using System.Linq;
using System.Reflection;
using Core.Interfaces;
using Core.Models.Dtos;
using EmailParser.Managers.Factory;
using EmailParser.Managers.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmailParser.Tests
{
    /// <summary>
    /// Unit tests for FactoryProvider class.
    /// </summary>
    [TestClass]
    public class FactoryProviderUnitTests
    {
        /// <summary>
        /// Test for BreakingNew email from Cnbc aggregator.
        /// </summary>
        [TestMethod]
        public void BreakingNews_CnbcParserFactory()
        {
            // Arrange
            EmailReader.Infrastructure.AutofacConfig.Configuration();
            var container = EmailReader.Infrastructure.AutofacConfig.Container;

            string[] files = Assembly.GetExecutingAssembly().GetManifestResourceNames()
                .Where(dir => dir.Contains("CnbcBreakingNews")).ToArray();

            Type targetType = new CnbcParser().GetType();
            IParser parser = null;

            foreach (var file in files)
            {
                var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(file);

                // Act
                using (StreamReader sr = new StreamReader(stream))
                {
                    EmailDto emailDto = new EmailDto
                    {
                        Subject = sr.ReadLine(),
                        From = sr.ReadLine(),
                        MessageId = Convert.ToInt32(sr.ReadLine()),
                        Body = sr.ReadToEnd()
                    };

                    parser = new ParserFactory().GetParser(emailDto, container);
                }

                // Assert
                Assert.IsInstanceOfType(parser, targetType);
            }
        }

        /// <summary>
        /// Test method for TechToday aggregator.
        /// </summary>
        [TestMethod]
        public void Lifewire_TechTodayFactory()
        {
            // Arrange
            EmailReader.Infrastructure.AutofacConfig.Configuration();
            var container = EmailReader.Infrastructure.AutofacConfig.Container;

            string[] files = Assembly.GetExecutingAssembly().GetManifestResourceNames().Where(
                dir => dir.Contains("TechToday")).ToArray();

            Type targetType = new TechTodayParser().GetType();
            IParser parser = null;

            foreach (var file in files)
            {
                var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(file);

                // Act
                using (StreamReader sr = new StreamReader(stream))
                {
                    EmailDto emailDto = new EmailDto
                    {
                        Subject = sr.ReadLine(),
                        From = sr.ReadLine(),
                        MessageId = Convert.ToInt32(sr.ReadLine()),
                        Body = sr.ReadToEnd()
                    };

                    parser = new ParserFactory().GetParser(emailDto, container);
                }

                // Assert
                Assert.IsInstanceOfType(parser, targetType);
            }
        }

        /// <summary>
        /// Test method for emails without need parser.
        /// </summary>
        [TestMethod]
        public void EmailsWithoutParserAndFactory_Null()
        {
            // Arrange
            EmailReader.Infrastructure.AutofacConfig.Configuration();
            var container = EmailReader.Infrastructure.AutofacConfig.Container;

            string[] files = Assembly.GetExecutingAssembly().GetManifestResourceNames().Where(
                dir => dir.Contains("Unknown")).ToArray();

            IParser parser = null;

            foreach (var file in files)
            {
                var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(file);

                // Act
                using (StreamReader sr = new StreamReader(stream))
                {
                    EmailDto emailDto = new EmailDto
                    {
                        Subject = sr.ReadLine(),
                        From = sr.ReadLine(),
                        MessageId = Convert.ToInt32(sr.ReadLine()),
                        Body = sr.ReadToEnd()
                    };

                    parser = new ParserFactory().GetParser(emailDto, container);
                }

                // Assert
                Assert.IsNull(parser);
            }
        }

        /// <summary>
        /// Gets the email dto based on test file.
        /// </summary>
        /// <param name="filePath">Path to the file.</param>
        /// <returns>EmailDto based on file content.</returns>
        private EmailDto GetDtoFromTestFiles(string filePath)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var stream = assembly.GetManifestResourceStream(filePath);

            using (StreamReader sr = new StreamReader(stream))
            {
                EmailDto emailDto = new EmailDto
                {
                    Subject = sr.ReadLine(),
                    From = sr.ReadLine(),
                    MessageId = Convert.ToInt32(sr.ReadLine()),
                    Body = sr.ReadToEnd()
                };

                return emailDto;
            }
        }
    }
}
