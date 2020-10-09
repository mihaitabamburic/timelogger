using Timelogger.Entities;

namespace Timelogger.Api
{
  public class ProjectSaver : IProjectSaver
  {
    private readonly ApiContext context;

    public ProjectSaver(ApiContext context)
    {
      this.context = context;
    }

    public void Save(int userId, ProjectModel projectModel)
    {
      var user = context.Users.Find(userId);

      var project = new Project
      {
        Deadline = projectModel.Deadline,
        Name = projectModel.Name,
        User = user
      };

      context.Projects.Add(project);

      context.SaveChanges();
    }
  }
}