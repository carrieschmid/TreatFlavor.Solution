using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Models
{
  public class RestaurantContext : DbContext
  {
    public virtual DbSet<Cuisines> Flavors { get; set; }
    public DbSet<Restaurants> Treats { get; set; }
    public DbSet<FlavorsTreats> FlavorsTreats { get; set; }

    public BakeryContext(DbContextOptions options) : base(options) { }
  }
}