using Infrastructure.Configuration;
using Infrastructure.Services.Interfaces;
using Infrastructure.Settings;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Services
{
    public class AppSettingsService : IAppSettingsService
    {
        private readonly IConfiguration _configuration;
        private readonly string _thisPath = AppDirectories.ConfigurationDirectory;

        public AppSettingsService()
        {
            _configuration = new ConfigurationBuilder()
                .SetBasePath(_thisPath)
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public SQLServerSettings GetSQLServerSettings()
        {
            var settings = new SQLServerSettings();
            _configuration.GetSection(nameof(SQLServerSettings)).Bind(settings);
            return settings;
        }


        public CORSSettings GetCORSSettings()
        {
            var settings = new CORSSettings();
            _configuration.GetSection(nameof(CORSSettings)).Bind(settings);
            return settings;
        }
    }
}
