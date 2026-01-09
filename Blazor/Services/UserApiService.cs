using Blazor.Models;

namespace Blazor.Services;

public class UserApiService
{
    private readonly HttpClient _http;

    public UserApiService(IHttpClientFactory factory)
    {
        _http = factory.CreateClient("MyApi");
    }

    public async Task<List<User>> GetUsersAsync()
    {
        return await _http.GetFromJsonAsync<List<User>>("api/users") ?? new List<User>();
    }
}