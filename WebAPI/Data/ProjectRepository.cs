using Dapper;
using WebAPI.Models;

namespace WebAPI.Data;

public class ProjectRepository
{
    private readonly DbConnectionFactory _factory;

    public ProjectRepository(DbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<Project>> GetAllAsync()
    {
        using var conn = await _factory.CreateConnectionAsync();
        return await conn.QueryAsync<Project>("SELECT id, name, url FROM projects");
    }
}