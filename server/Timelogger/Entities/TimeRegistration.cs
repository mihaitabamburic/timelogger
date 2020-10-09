using System;

namespace Timelogger.Entities
{
  public class TimeRegistration
  {
    public int TimeRegistrationId { get; set; }
    public int TimeLogged { get; set; }
    public DateTime CreatedAt { get; set; }
    public Project Project { get; set; }
  }
}
