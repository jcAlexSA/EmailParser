using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailParsersFactory.Infrastructure
{
    public class ApplicationConfiguration
    {
        public string Login { get; } = "news.fake.aggregator@gmail.com";

        public string Password { get; } = "fake.news";

        //TODO: set here path to directory where download file.
    }
}
