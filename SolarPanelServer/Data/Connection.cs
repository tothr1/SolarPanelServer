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
            SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dt);
                conn.Close();
                adapter.Dispose();
                return dt;
                
            
        }
        public static void addQuery(string query)
        {
            DataTable dt = new DataTable();
            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.ExecuteNonQuery();

        }
    }
}
