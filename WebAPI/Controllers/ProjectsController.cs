using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Services;

namespace WebAPI.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly ProjectService _projectService;

    public ProjectsController(ProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Project>>> GetProjects([FromQuery] int page, [FromQuery] int pageSize)
    {
        var projects = await _projectService.GetAll(page, pageSize);
        return Ok(projects);
    }
}