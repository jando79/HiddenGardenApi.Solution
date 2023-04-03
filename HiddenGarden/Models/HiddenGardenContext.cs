using Microsoft.EntityFrameworkCore;
using HiddenGarden.Models;

namespace HiddenGarden.Models
{
  public class HiddenGardenContext : DbContext
  {
    public DbSet<Backyard> Backyards {get; set; }

    public HiddenGardenContext(DbContextOptions<HiddenGardenContext> options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Backyard>()
        .HasData(
          new Backyard { BackyardId = 1, Service = "Fig trees", Description = "Free fig tree fruit", Address = "13704 SE Salmon St, Portland OR, 97233" , Instructions = "Pay $5, follow road signs"}
        );
    }
  }
}
