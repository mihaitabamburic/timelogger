using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Timelogger.Entities;
using Microsoft.AspNetCore.Mvc;
using System;

[assembly: ApiController]
namespace Timelogger.Api
{
  public class Startup
  {
    private readonly IWebHostEnvironment _environment;
    public IConfigurationRoot Configuration { get; }

    public Startup(IWebHostEnvironment env)
    {
      _environment = env;

      var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        .AddEnvironmentVariables();
      Configuration = builder.Build();
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      DependencyInjectionSetup.RegisterServices(services);
      // Add framework services.
      services.AddLogging(builder =>
      {
        builder.AddConsole();
        builder.AddDebug();
      });

      if (_environment.IsDevelopment())
      {
        services.AddCors();
      }

      services.AddRouting(o => o.LowercaseUrls = true);

      services.AddMvc(options => options.EnableEndpointRouting = false);

      services.AddSwaggerGen();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseMiddleware<ExceptionHandlerMiddleware>();

      if (env.IsDevelopment())
      {
        app.UseCors(builder => builder
          .AllowAnyMethod()
          .AllowAnyHeader()
          .SetIsOriginAllowed(origin => true)
          .WithOrigins("http://localhost:3000")
          .AllowCredentials());
      }

      app.UseMvc();

      app.UseSwagger();
      app.UseSwaggerUI(o => o.SwaggerEndpoint("/swagger/v1/swagger.json", "Timelogger API V1"));

      var serviceScopeFactory = app.ApplicationServices.GetService<IServiceScopeFactory>();
      using (var scope = serviceScopeFactory.CreateScope())
      {
        SeedDatabase(scope);
      }
    }

    private static void SeedDatabase(IServiceScope scope)
    {
      var context = scope.ServiceProvider.GetService<ApiContext>();

      var testUser = new User
      {
        UserId = 1,
        Name = "The OG Freelancer"
      };

      var testProject1 = new Entities.Project
      {
        ProjectId = 1,
        Name = "Favorite Client",
        Deadline = DateTime.UtcNow.AddDays(1),
        User = testUser
      };

      var testProject2 = new Entities.Project
      {
        ProjectId = 2,
        Name = "Least Favorite Client",
        Deadline = DateTime.UtcNow.AddDays(1),
        User = testUser
      };

      context.Users.Add(testUser);
      context.Projects.Add(testProject1);
      context.Projects.Add(testProject2);

      context.SaveChanges();
    }
  }
}