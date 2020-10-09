using System;

namespace Timelogger.Api
{
  public class DateTimeService : IDateTimeService
  {
    public DateTime GetUtcNow()
    {
      return DateTime.UtcNow;
    }
  }

  public interface IDateTimeService
  {
    DateTime GetUtcNow();
  }
}