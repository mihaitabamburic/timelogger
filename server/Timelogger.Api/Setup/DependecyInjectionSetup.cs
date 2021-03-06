using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Timelogger.Api
{
  public static class DependencyInjectionSetup
  {
    public static void RegisterServices(IServiceCollection service)
    {
      service.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("e-conomic interview"));

      service.AddScoped(typeof(IProjectOverviewsByUserLoader), typeof(ProjectOverviewsByUserLoader));
      service.AddScoped(typeof(ITimeRegistrationsByProjectLoader), typeof(TimeRegistrationsByProjectLoader));
      service.AddScoped(typeof(IProjectSaver), typeof(ProjectSaver));
      service.AddScoped(typeof(ITimeRegistrationSaver), typeof(TimeRegistrationSaver));
      service.AddScoped(typeof(IProjectLoader), typeof(ProjectLoader));
      service.AddScoped(typeof(ITimeRegistrationSaveBusinessService), typeof(TimeRegistrationSaveBusinessService));
      service.AddScoped(typeof(IDateTimeService), typeof(DateTimeService));
    }
  }
}