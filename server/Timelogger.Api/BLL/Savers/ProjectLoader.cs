using Timelogger.Entities;

namespace Timelogger.Api
{
  public class ProjectLoader : IProjectLoader
  {
    private readonly ApiContext context;

    public ProjectLoader(ApiContext context)
    {
      this.context = context;
    }

    public Project Load(int projectId)
    {
      return context.Projects.Find(projectId);
    }
  }
}