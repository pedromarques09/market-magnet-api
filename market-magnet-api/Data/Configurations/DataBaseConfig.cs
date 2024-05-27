namespace market_magnet_api.Data.Configurations
{
    public class DataBaseConfig : IDataBaseConfig
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
