using Dapper;
using WebAPI.Models;

namespace WebAPI.Data;

public class UserRepository
{
    private readonly DbConnectionFactory _factory;

    public UserRepository(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<User>> GetAllAsync()
    {
        using var conn = await _factory.CreateConnectionAsync();
        return await conn.QueryAsync<User>("SELECT id, name, email FROM users");
    }
}