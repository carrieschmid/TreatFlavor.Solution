namespace Bakery.Models
{
  public class FlavorsTreats
    {       
        public int FlavorsTreatsId { get; set; }
        public int TreatsId { get; set; }
        public int FlavorsId { get; set; }
        public Treats Treats { get; set; }
        public Flavors Flavors { get; set; }
    }
}