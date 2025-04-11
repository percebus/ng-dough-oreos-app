namespace WebApp.Options
{
    using Connectors.Options;

    public class ServiceOptions
    {
        public static string Key = "FirstApp";

        public DatabaseOptions Database { get; set; } = new();
    }
}
