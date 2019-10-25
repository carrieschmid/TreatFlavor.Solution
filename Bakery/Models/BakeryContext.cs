using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Bakery.Models;


namespace BasicAuthentication.Models
{
  public class BakeryContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Flavors> Flavors { get; set; }
    public DbSet<Treats> Treats { get; set; }
    public DbSet<FlavorsTreats> FlavorsTreats { get; set; }

    public BakeryContext(DbContextOptions options) : base(options) { }
  }
}