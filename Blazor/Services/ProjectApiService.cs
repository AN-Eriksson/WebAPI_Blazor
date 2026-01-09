using Blazor.Models;

namespace Blazor.Services;

public class ProjectApiService
{
    private readonly HttpClient _http;

    public ProjectApiService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("MyApi");
    }

    public async Task<List<Project>> GetProjectsAsync()
    {
        return await _http.GetFromJsonAsync<List<Project>>("api/projects") ?? new List<Project>();
    }
}