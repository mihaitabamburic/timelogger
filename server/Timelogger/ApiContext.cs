using Microsoft.EntityFrameworkCore;
using Timelogger.Entities;

namespace Timelogger
{
  public class ApiContext : DbContext
  {
    public ApiContext(DbContextOptions<ApiContext> options)
      : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder){
      modelBuilder.Entity<Project>()
      .HasOne(a => a.User)
      .WithMany(b => b.Projects);

      modelBuilder.Entity<User>()
      .HasMany(a => a.Projects)
      .WithOne(b => b.User);

      modelBuilder.Entity<TimeRegistration>()
      .HasOne(a => a.Project)
      .WithMany(b => b.TimeRegistrations);
    }

    public DbSet<Project> Projects { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<TimeRegistration> TimeRegistrations { get; set; }
  }
}
