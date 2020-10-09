using System;
using System.ComponentModel.DataAnnotations;

namespace Timelogger.Api
{
  public class ProjectModel
  {
    [Required]
    public string Name { get; set; }
    public DateTime Deadline { get; set; }
  }
}