using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Models
{
  public class BakeryContext : DbContext
  {
    public virtual DbSet<Flavors> Flavors { get; set; }
    public DbSet<Treats> Treats { get; set; }
    public DbSet<FlavorsTreats> FlavorsTreats { get; set; }

    public BakeryContext(DbContextOptions options) : base(options) { }
  }
}