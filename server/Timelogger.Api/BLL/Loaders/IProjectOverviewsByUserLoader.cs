using System.Collections.Generic;

namespace Timelogger.Api
{
  public interface IProjectOverviewsByUserLoader
  {
    List<ProjectOverviewModel> Load(int userId);
  }
}