using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Services;

public class ProjectService
{
    private readonly ProjectRepository _projectRepository;

    public ProjectService(ProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    public async Task<IEnumerable<Project>> GetAll()
    {
        return await _projectRepository.GetAllAsync();
    }
}