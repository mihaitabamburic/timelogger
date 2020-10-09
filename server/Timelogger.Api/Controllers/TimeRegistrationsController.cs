using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Timelogger.Api
{
  [ApiController]
  [Route("api/v1/[controller]")]
  [Produces("application/json")]
  public class TimeRegistrationsController : ControllerBase
  {
    private readonly ITimeRegistrationSaveBusinessService timeRegistrationSaveBusinessService;
    private readonly ITimeRegistrationsByProjectLoader timeRegistrationsByProjectLoader;

    public TimeRegistrationsController(
      ITimeRegistrationSaveBusinessService timeRegistrationSaveBusinessService,
      ITimeRegistrationsByProjectLoader timeRegistrationsByProjectLoader)
    {
      this.timeRegistrationSaveBusinessService = timeRegistrationSaveBusinessService;
      this.timeRegistrationsByProjectLoader = timeRegistrationsByProjectLoader;
    }

    [HttpPost]
    [Route("projects/{projectId}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult SaveTimeRegistration(
      [FromRoute] int projectId,
      [FromBody] TimeRegistrationModel timeRegistrationModel)
    {
      if (timeRegistrationSaveBusinessService.Execute(projectId, timeRegistrationModel))
      {
        return NoContent();
      }
      return BadRequest();
    }

    [HttpGet]
    [Route("projects/{projectId}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetTimeRegistrationsByProject([FromRoute] int projectId)
    {
      var timeRegistrations = timeRegistrationsByProjectLoader.Load(projectId);

      if (!timeRegistrations.Any())
      {
        return NotFound();
      }

      return Ok(timeRegistrations);
    }
  }
}
