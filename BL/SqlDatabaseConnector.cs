using Microsoft.Data.SqlClient;
using YiunHa.BL;
using Microsoft.Extensions.Configuration;

namespace YiunHa
{
    public class SqlDatabaseConnector
    {
        public HelpFunction helpFunction = new HelpFunction();
        public SqlConnection connection;
        private SqlCommand cmd;
        //private readonly IConfiguration _configuration;

        public SqlDatabaseConnector()
        {
            string connectionStrong = new ConfigurationBuilder().AddJsonFile("appsettings.production.json").Build().GetConnectionString("iyun");
            //string connectionStrong = configuration.GetConnectionString("iyun");
            connection = new SqlConnection(connectionStrong);
            cmd = connection.CreateCommand();
        }

        public int OpenConnection(string connectionString)
        {
            connection.Open();
            cmd.CommandText = connectionString;
            cmd.Connection = connection;
            int rowAffected = cmd.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public SqlDataReader OpenConnectionAndReturnReader(string connectionString)
        {
            connection.Open();
            cmd.CommandText = connectionString;
            cmd.Connection = connection;
            return cmd.ExecuteReader();
        }
    }
}
