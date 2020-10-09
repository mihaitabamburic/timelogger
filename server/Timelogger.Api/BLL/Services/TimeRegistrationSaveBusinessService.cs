using System;

namespace Timelogger.Api
{
  public class TimeRegistrationSaveBusinessService : ITimeRegistrationSaveBusinessService
  {
    private readonly IProjectLoader projectLoader;
    private readonly ITimeRegistrationSaver timeRegistrationSaver;
    private readonly IDateTimeService dateTimeService;

    public TimeRegistrationSaveBusinessService(
      IProjectLoader projectLoader,
      ITimeRegistrationSaver timeRegistrationSaver,
      IDateTimeService dateTimeService)
    {
      this.projectLoader = projectLoader;
      this.timeRegistrationSaver = timeRegistrationSaver;
      this.dateTimeService = dateTimeService;
    }

    public bool Execute(int projectId, TimeRegistrationModel timeRegistrationModel)
    {
      var project = projectLoader.Load(projectId);

      if (CanBeSaved(project))
      {
        timeRegistrationSaver.Save(project, timeRegistrationModel);
        return true;
      }

      return false;
    }

    private bool CanBeSaved(Entities.Project project)
    {
      return project != null && project.Deadline > dateTimeService.GetUtcNow();
    }
  }
}