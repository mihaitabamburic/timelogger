using Timelogger.Entities;

namespace Timelogger.Api
{
  public interface IProjectLoader
  {
    Project Load(int projectId);
  }
}