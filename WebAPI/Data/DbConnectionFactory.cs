using System.Data;
using MySqlConnector;

namespace WebAPI.Data;

public class DbConnectionFactory
{
    private readonly IConfiguration _config;

    public DbConnectionFactory(IConfiguration config)
    {
        _config = config;
    }

    public async Task<IDbConnection> CreateConnectionAsync()
    {
        var conn = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
        await conn.OpenAsync();
        return conn;
    }
}