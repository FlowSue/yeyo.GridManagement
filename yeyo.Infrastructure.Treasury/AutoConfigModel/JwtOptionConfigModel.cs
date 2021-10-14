using Microsoft.Extensions.Configuration;

namespace yeyo.Infrastructure.Treasury.AutoConfigModel
{
    public interface IJwtOptionConfig
    {
        /// <summary>
        /// 安全密钥
        /// </summary>
        string SecurityKey { get; }

        /// <summary>
        /// Web端过期时间
        /// </summary>
        double WebExp { get; }

        /// <summary>
        /// 移动端过期时间
        /// </summary>
        double AppExp { get; }

        /// <summary>
        /// 小程序过期时间
        /// </summary>
        double MiniProgramExp { get; }

        /// <summary>
        /// 其他端过期时间
        /// </summary>
        double OtherExp { get; }
    }

    public class JwtOptionConfig : IJwtOptionConfig
    {
        private readonly IConfigurationSection _configSection;

        public JwtOptionConfig(IConfiguration configuration)
        {
            _configSection = configuration.GetSection("JwtOption");
        }
        
        public string SecurityKey => _configSection.GetValue("SecurityKey", "yeyo");
        
        public double WebExp => _configSection.GetValue<double>("WebExp", 30);
        
        public double AppExp => _configSection.GetValue<double>("AppExp", 30);
        
        public double MiniProgramExp => _configSection.GetValue<double>("MiniProgramExp", 30);
        
        public double OtherExp => _configSection.GetValue<double>("OtherExp", 30);
    }
}
