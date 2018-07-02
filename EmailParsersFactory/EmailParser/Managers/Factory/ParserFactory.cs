using Autofac;
using Core.Interfaces;
using Core.Models.Dtos;

namespace EmailParser.Managers.Factory
{
    /// <summary>
    /// Class to provide specify factory based on EmailDto.From property.
    /// </summary>
    public class ParserFactory
    {
        /// <summary>
        /// Gets the specify factory based on EmailDto.
        /// </summary>
        /// <param name="emailDto">The email dto.</param>
        /// <param name="container">The container.</param>
        /// <returns>The specify parser.</returns>
        public IParser GetParser(EmailDto emailDto, IContainer container)
        {
            string key = this.GetKey(emailDto);

            try
            {
                return container.ResolveNamed<IParser>(key);
            }
            catch (Autofac.Core.Registration.ComponentNotRegisteredException)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the key from emailDto.
        /// </summary>
        /// <param name="emailDto">The email dto.</param>
        /// <returns>The key for autofac.</returns>
        private string GetKey(EmailDto emailDto)
        {
            int leftBracket = 0, rightBraket = 0;
            leftBracket = emailDto.From.LastIndexOf("<");
            rightBraket = emailDto.From.LastIndexOf(">");
            if (rightBraket <= 0)
            {
                return string.Empty;
            }

            return emailDto.From.Substring(++leftBracket, rightBraket - leftBracket);
        }
    }
}
