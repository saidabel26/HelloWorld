using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MySqlConnector;

namespace HelloWorld.Core.Application.Repositories
{
    public class NamesRepository : INamesRepository
    {
        private readonly string _connectionString;

        public NamesRepository(string connectionString) => _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));

        public async Task InitializeAsync(CancellationToken cancellationToken = default)
        {
            await using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync(cancellationToken);
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS names (
                    Id INT AUTO_INCREMENT PRIMARY KEY,
                    Name VARCHAR(200) NOT NULL
                );";
            await cmd.ExecuteNonQueryAsync(cancellationToken);
        }

        public async Task<IEnumerable<string>> GetNamesAsync(CancellationToken cancellationToken = default)
        {
            var list = new List<string>();
            await using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync(cancellationToken);
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT Name FROM names ORDER BY Id DESC;";
            await using var rdr = await cmd.ExecuteReaderAsync(cancellationToken);
            while (await rdr.ReadAsync(cancellationToken))
            {
                list.Add(rdr.GetString(0));
            }
            return list;
        }

        public async Task AddNameAsync(string name, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(name)) return;
            await using var conn = new MySqlConnection(_connectionString);
            await conn.OpenAsync(cancellationToken);
            await using var cmd = conn.CreateCommand();
            cmd.CommandText = "INSERT INTO names (Name) VALUES (@name);";
            cmd.Parameters.AddWithValue("@name", name);
            await cmd.ExecuteNonQueryAsync(cancellationToken);
        }
    }
}