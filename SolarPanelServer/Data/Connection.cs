using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace SolarPanelServer.Data
{
    public static class Connection
    {
        private static IConfigurationBuilder builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appSettings.json", optional: true, reloadOnChange: true);
        private static IConfiguration _configuration = builder.Build();
        private static string connString = _configuration.GetConnectionString(name: "SolarPanel");

        public static DataTable runQuery(string query)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connString);
            using(SqlCommand cmd = new SqlCommand())
            {
                conn.Open();
                cmd.CommandText = query;
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.Fill(dt);
                conn.Close();
                adapter.Dispose();
                return dt;
                
            }
        }
    }
}
