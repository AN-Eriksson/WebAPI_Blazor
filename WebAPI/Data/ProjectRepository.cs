using System.Data;
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

    public async Task<IEnumerable<Project>> GetAllAsync(int page = 1, int pageSize = 5)
    {
        if (page < 1) page = 1;
        if (pageSize < 1) pageSize = 5;

        var offset = (page - 1) * pageSize;
        const string sql = @"
        SELECT id, name, url
        FROM projects
        ORDER BY id
        LIMIT @PageSize OFFSET @Offset";

        using var conn = await _factory.CreateConnectionAsync();
        
        // Dapper direkt SQL
        // return await conn.QueryAsync<Project>(sql, new { PageSize = pageSize, Offset = offset });
        
        // Stored procedure
        return await conn.QueryAsync<Project>(
            "GetProjects",
            new { p_PageSize = pageSize, p_Offset = offset },
            commandType: CommandType.StoredProcedure);
    }
}