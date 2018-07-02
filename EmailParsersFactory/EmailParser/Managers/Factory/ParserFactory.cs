using System.Text.RegularExpressions;
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
            string pattern = @"(?("")("".+?(?<!\\)\""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`{}|~\w])*)(?<=[0-9a-z])@))(?([)([(\d{1,3}.){3}\d{1,3}])|(([0-9a-z][-0-9a-z]*[0-9a-z]*.)+[a-z0-9][-a-z0-9]{0,22}[a-z0-9]))";
            Regex regex = new Regex(pattern);

            if(regex.IsMatch(emailDto.From))
            {
                var result = regex.Match(emailDto.From);
                return result.Value.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
