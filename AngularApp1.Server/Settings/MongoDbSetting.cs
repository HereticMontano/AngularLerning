namespace AngularApp1.Server.Settings // o donde prefieras
{
    public class MongoDbSetting
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
    }
}