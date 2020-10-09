using System;

namespace Timelogger.Api
{
  public class ProjectOverviewModel
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int TimeLogged { get; set; }
    public DateTime Deadline { get; set; }
  }
}