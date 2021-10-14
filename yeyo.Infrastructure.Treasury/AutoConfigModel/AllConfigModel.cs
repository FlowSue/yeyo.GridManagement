using Microsoft.Extensions.Configuration;

namespace yeyo.Infrastructure.Treasury.AutoConfigModel
{
    public interface IAllConfigModel
    {
        IJwtOptionConfig JwtOptionConfig { get; }
        IConnectionStringsModel ConnectionStrings { get; }
        SwaggerDoc SwaggerDoc { get; }
    }

    public class AllConfigModel : IAllConfigModel
    {
        private readonly IConfiguration _configuration;

        public AllConfigModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IJwtOptionConfig JwtOptionConfig => new JwtOptionConfig(_configuration);

        public IConnectionStringsModel ConnectionStrings => new ConnectionStringsModel(_configuration);

        public SwaggerDoc SwaggerDoc => new SwaggerDoc(_configuration);
    }
}
