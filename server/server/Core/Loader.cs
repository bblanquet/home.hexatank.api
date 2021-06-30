using Npgsql;
using System;
using System.Threading.Tasks;

namespace server.Core
{
    public class Loader
    {
        public async Task Load()
        {
            try
            {
                var connString = "Host=10.152.183.182;Port=5432;Username=admin;Password=admin123;Database=postgresdb";
                Console.WriteLine($"try {connString}");

                await using var conn = new NpgsqlConnection(connString);
                await conn.OpenAsync();

                // Retrieve all rows
                await using (var cmd = new NpgsqlCommand("SELECT name FROM USER", conn))
                await using (var reader = await cmd.ExecuteReaderAsync())
                    while (await reader.ReadAsync())
                        Console.WriteLine(reader.GetString(0));

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }
}
