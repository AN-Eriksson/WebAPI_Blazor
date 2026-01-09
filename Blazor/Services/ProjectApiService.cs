using Blazor.Models;

namespace Blazor.Services;

public class ProjectApiService
{
    private readonly HttpClient _http;

    public ProjectApiService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("MyApi");
    }

    public async Task<List<Project>> GetProjectsAsync(int page, int pageSize)
    {
        var url = $"api/projects?page={page}&pageSize={pageSize}";
        var res = await _http.GetFromJsonAsync<List<Project>>(url);
        return res ?? new List<Project>();
    }
}