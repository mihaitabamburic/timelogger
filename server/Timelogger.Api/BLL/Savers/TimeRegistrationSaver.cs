using System;
using Timelogger.Entities;

namespace Timelogger.Api
{
  public class TimeRegistrationSaver : ITimeRegistrationSaver
  {
    private readonly ApiContext context;

    public TimeRegistrationSaver(ApiContext context)
    {
      this.context = context;
    }

    public void Save(int projectId, TimeRegistrationModel timeRegistrationModel)
    {
      var project = context.Projects.Find(projectId);

      var timeRegistration = new TimeRegistration
      {
        TimeLogged = timeRegistrationModel.MinutesWorked,
        CreatedAt = DateTime.UtcNow,
        Project = project
      };

      context.TimeRegistrations.Add(timeRegistration);

      context.SaveChanges();
    }
  }
}