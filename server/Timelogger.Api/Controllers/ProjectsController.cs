using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Timelogger.Api
{
  [ApiController]
  [Route("api/v1/[controller]")]
  [Produces("application/json")]
  public class ProjectsController : ControllerBase
  {
    private readonly IProjectOverviewsByUserLoader projectsByUserLoader;
    private readonly IProjectSaver projectSaver;

    public ProjectsController(
      IProjectOverviewsByUserLoader projectsByFreelancerLoader,
      IProjectSaver projectSaver)
    {
      this.projectsByUserLoader = projectsByFreelancerLoader;
      this.projectSaver = projectSaver;
    }

    [HttpGet]
    [Route("users/{userId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetProjectsByUser([FromRoute] int userId)
    {
      var projects = projectsByUserLoader.Load(userId);

      if (!projects.Any())
      {
        return NotFound();
      }

      return Ok(projects);
    }

    [HttpPost]
    [Route("users/{userId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult SaveProject([FromRoute] int userId, [FromBody] ProjectModel projectModel)
    {
      projectSaver.Save(userId, projectModel);
      return NoContent();
    }
  }
}
