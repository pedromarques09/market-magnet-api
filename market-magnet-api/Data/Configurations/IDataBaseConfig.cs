namespace market_magnet_api.Data.Configurations
{
    public interface IDataBaseConfig
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }

    }
}
