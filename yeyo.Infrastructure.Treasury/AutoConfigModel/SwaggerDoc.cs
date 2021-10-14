using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace yeyo.Infrastructure.Treasury.AutoConfigModel
{
    public class SwaggerDoc
    {
        private readonly IConfigurationSection _configSection;

        public SwaggerDoc(IConfiguration configuration)
        {
            _configSection = configuration.GetSection("SwaggerDoc");
        }

        public string ContactName => _configSection.GetValue("ContactName", "");
        public string ContactEmail => _configSection.GetValue("ContactEmail", "");
        public Uri ContactUrl => _configSection.GetValue("ContactUrl", new Uri("http://www.hnyeyo.com/"));
        public string Version => _configSection.GetValue("Version", "");
        public string Title => _configSection.GetValue("Title", "");
        public string Description => _configSection.GetValue("Description", "");
        public string Route => _configSection.GetValue("Route", "");
        public string ApiName => _configSection.GetValue("ApiName", "ApiHelp V1");
    }
}
