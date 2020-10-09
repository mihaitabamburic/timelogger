namespace Timelogger.Api
{
  public interface ITimeRegistrationSaver
  {
    void Save(int projectId, TimeRegistrationModel timeRegistrationModel);
  }
}