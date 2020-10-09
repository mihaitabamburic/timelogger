using System.Collections.Generic;
using Timelogger.Entities;

namespace Timelogger.Api
{
  public interface ITimeRegistrationsByProjectLoader
  {
    List<TimeRegistration> Load(int projectId);
  }
}