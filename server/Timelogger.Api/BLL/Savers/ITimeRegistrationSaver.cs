namespace Timelogger.Api
{
  public interface ITimeRegistrationSaver
  {
    bool Save(int projectId, TimeRegistrationModel timeRegistrationModel);
  }
}