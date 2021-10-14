using Microsoft.Extensions.Configuration;

namespace yeyo.Infrastructure.Treasury.AutoConfigModel
{
    public interface IConnectionStringsModel 
    {
        string SqlServer { get; }
        string MySql { get; }
        string SqlLite { get; }
    }

    public class ConnectionStringsModel : IConnectionStringsModel
    {
        private readonly IConfigurationSection _configSection;

        public ConnectionStringsModel(IConfiguration configuration)
        {
            _configSection = configuration.GetSection("ConnectionStrings");
        }
        public string SqlServer => _configSection.GetValue("SqlServer", string.Empty);
        public string MySql => _configSection.GetValue("MySql", string.Empty);
        public string SqlLite => _configSection.GetValue("SqlLite", string.Empty);
    }
}
