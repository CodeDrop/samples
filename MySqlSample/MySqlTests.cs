using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;

namespace MySqlSample
{
    public class MySqlTests
    {
        [Test]
        public async Task ConnectToMySqlAsync()
        {
            using MySqlConnection conn = OpenConnection();
            conn.Open();
            Assert.That(conn.State, Is.EqualTo(System.Data.ConnectionState.Open));

            using MySqlCommand command = conn.CreateCommand();
            command.CommandText = "SELECT name from media";

            using MySqlDataReader reader = (MySqlDataReader)await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                string name = reader.GetString(0);
                await TestContext.Out.WriteLineAsync(name);
            }
        }

        private static MySqlConnection OpenConnection()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<MySqlTests>(optional: true);

            var config = builder.Build();

            string dbserver = config["dbserver"] ?? "";
            string dbname = config["dbname"] ?? "";
            string dbuser = config["dbuser"] ?? "";
            string dbpassword = config["dbpassword"] ?? "";

            var csb = new MySqlConnectionStringBuilder
            {
                Server = dbserver,
                Database = dbname,
                UserID = dbuser,
                Password = dbpassword,
                SslMode = MySqlSslMode.VerifyFull,
            };
            return new MySqlConnection(csb.ConnectionString);
        }
    }
}
