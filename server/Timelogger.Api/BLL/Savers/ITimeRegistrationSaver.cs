using Timelogger.Entities;

namespace Timelogger.Api
{
  public interface ITimeRegistrationSaver
  {
    void Save(Project project, TimeRegistrationModel timeRegistrationModel);
  }
}