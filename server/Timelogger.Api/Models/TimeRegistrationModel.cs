using System;
using System.ComponentModel.DataAnnotations;

namespace Timelogger.Api
{
  public class TimeRegistrationModel
  {
    [Required]
    [Range(30, int.MaxValue)]
    public int MinutesWorked { get; set; }
  }
}