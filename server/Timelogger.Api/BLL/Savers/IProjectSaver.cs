namespace Timelogger.Api
{
  public interface IProjectSaver
  {
    void Save(int userId, ProjectModel projectModel);
  }
}