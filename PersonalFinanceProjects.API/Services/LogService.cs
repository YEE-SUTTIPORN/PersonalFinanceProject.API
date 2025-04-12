using Microsoft.Data.SqlClient;

namespace PersonalFinanceProjects.API.Services
{
    public class LogService
    {
        private readonly string _connectionString;

        public LogService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";
        }

        public async Task WriteLogAsync(string message, string level, string exception = null)
        {
            var query = "INSERT INTO Logs (Message, Level, TimeStamp, Exception) VALUES (@Message, @Level, @TimeStamp, @Exception)";

            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();  // เปิดการเชื่อมต่อแบบ Async

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Message", message);
                    command.Parameters.AddWithValue("@Level", level);
                    command.Parameters.AddWithValue("@TimeStamp", DateTime.UtcNow);
                    command.Parameters.AddWithValue("@Exception", exception == null ? DBNull.Value : exception);

                    await command.ExecuteNonQueryAsync();  // เรียกใช้ ExecuteNonQueryAsync แบบ Async
                }
            }
        }

    }
}
