using Microsoft.Extensions.Configuration;
using System.IO;

namespace TechnicalTest
{
   public class ConfigurationProvider
    {
        private readonly IConfiguration _config;

        public ConfigurationProvider()
        {
            _config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", false)
                .Build();
        }

        public string GetUrl()
        {
            return _config.GetSection("url").Value;
        }
    }
}