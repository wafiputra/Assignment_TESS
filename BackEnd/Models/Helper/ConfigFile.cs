namespace assignment_tess.Models.Helper
{
    public class ConfigFile
    {
        private readonly IConfiguration _configFile;

        public ConfigFile()
        {
            var builder = new ConfigurationBuilder().SetBasePath(AppContext.BaseDirectory).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            _configFile = builder.Build();
        }

        public string GetConnectionString(string key)
        {
            return _configFile.GetConnectionString(key);
        }

        public string GetAppSetting(string key)
        {
            return _configFile.GetSection("AppSetting").GetSection(key).Value;
        }

        public List<string> GetListAppSetting(string key)
        {
            List<string> corsList = _configFile.GetSection("AppSetting").GetSection(key).Get<List<string>>();
            return corsList;
        }
    }
}
