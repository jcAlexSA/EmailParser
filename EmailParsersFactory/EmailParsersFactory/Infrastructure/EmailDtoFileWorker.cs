using System;
using System.IO;
using Core.Models.Dtos;

namespace EmailParsersFactory.Infrastructure
{
    /// <summary>
    /// Class to read/write emails dto from/to io.stream.
    /// </summary>
    public class EmailDtoFileWorker
    {
        /// <summary>
        /// Gets the email dto from stream reader.
        /// </summary>
        /// <param name="sr">The stream reader.</param>
        /// <returns>The EmailDto read from stream.</returns>
        public static EmailDto GetEmailDto(StreamReader sr)
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
        /// Writes the email dto to the stream writer.
        /// </summary>
        /// <param name="sw">The stream writer.</param>
        /// <param name="dto">The email dto.</param>
        public static async void WriteEmailDto(StreamWriter sw, EmailDto dto)
        {
            var sb = new System.Text.StringBuilder(dto.Subject);
            sb.AppendLine(dto.From);
            sb.AppendLine(dto.MessageId.ToString());
            sb.AppendLine(dto.Body);

            await sw.WriteLineAsync(sb.ToString());
            await sw.FlushAsync();
            //sw.WriteLine(dto.Subject);
            //sw.WriteLine(dto.From);
            //sw.WriteLine(dto.MessageId);
            //sw.WriteLine(dto.Body);
        }
    }
}
