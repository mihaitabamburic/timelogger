using System.Collections.Generic;

namespace Timelogger.Entities
{
  public class User
  {
    public int UserId { get; set; }
    public string Name { get; set; }
    public ICollection<Project> Projects {get;set;}
    public ICollection<TimeRegistration> TimeRegistrations {get;set;}
  }
}
