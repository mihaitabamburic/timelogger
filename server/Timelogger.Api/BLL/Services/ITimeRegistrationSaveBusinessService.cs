namespace Timelogger.Api
{
  public interface ITimeRegistrationSaveBusinessService
  {
    bool Execute(int projectId, TimeRegistrationModel timeRegistrationModel);
  }
}