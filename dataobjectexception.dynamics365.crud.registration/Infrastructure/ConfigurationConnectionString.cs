namespace dataobjectexception.dynamics365.crud.registration.Infrastructure
{
    public sealed class ConfigurationConnectionString
    {
        public static string ConnectionString { get; set; }

        public static string GetConnectionStringInitialized(string AuthType, string UserName, string Password, string Url)
        {
            ConnectionString = "AuthType=Office365;Username=user@domain.com;Password=password;Integrated Security=true;Url=https://org.crm.dynamics.com;";
            return ConnectionString;
        }
    }
}
