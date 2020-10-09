namespace Timelogger.Api
{
  public class TimeRegistrationSaveBusinessService : ITimeRegistrationSaveBusinessService
  {
    private readonly IProjectLoader loader;
    private readonly ITimeRegistrationSaver saver;

    public TimeRegistrationSaveBusinessService(IProjectLoader loader, ITimeRegistrationSaver saver)
    {
      this.loader = loader;
      this.saver = saver;
    }

    public bool Execute(int projectId, TimeRegistrationModel timeRegistrationModel)
    {
      var project = loader.Load(projectId);

      if (project != null)
      {
        saver.Save(project, timeRegistrationModel);
        return true;
      }

      return false;
    }
  }
}