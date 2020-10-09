using System.Collections.Generic;
using System.Linq;
using Timelogger.Entities;

namespace Timelogger.Api
{
  public class TimeRegistrationsByProjectLoader : ITimeRegistrationsByProjectLoader
  {
    private readonly ApiContext context;

    public TimeRegistrationsByProjectLoader(ApiContext context)
    {
      this.context = context;
    }

    public List<TimeRegistration> Load(int projectId)
    {
      return context.TimeRegistrations
      .Where(tr => tr.Project.ProjectId == projectId)
      .ToList();
    }
  }
}