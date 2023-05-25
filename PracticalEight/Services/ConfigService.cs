using Microsoft.Extensions.Configuration;

namespace Organization.Services
{
    public static class ConfigService
    {
        private static readonly IConfiguration _config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        public static string Get(string name)
        {
            return _config[name]!;
        }
        public static IConfigurationSection GetSection(string name)
        {
            return _config.GetSection(name);
        }
    }
}
