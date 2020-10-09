using System.Collections.Generic;
using System.Linq;

namespace Timelogger.Api
{
  public class ProjectOverviewsByUserLoader : IProjectOverviewsByUserLoader
  {
    private readonly ApiContext context;

    public ProjectOverviewsByUserLoader(ApiContext context)
    {
      this.context = context;
    }

    public List<ProjectOverviewModel> Load(int userId)
    {
      var projectOverviews = new List<ProjectOverviewModel>();

      var projects = context.Projects
      .Where(p => p.User.UserId == userId)
      .OrderByDescending(p => p.Deadline)
      .ToList();

      foreach (var project in projects)
      {
        var timeLogged = (double)context.TimeRegistrations
        .Where(tr => tr.Project.ProjectId == project.ProjectId)
        .Sum(tr => tr.TimeLogged) / (double)60;

        projectOverviews.Add(new ProjectOverviewModel
        {
          Deadline = project.Deadline,
          Id = project.ProjectId,
          Name = project.Name,
          TimeLogged = timeLogged
        });
      }

      return projectOverviews;
    }
  }
}