using System.Collections.Generic;

namespace Bakery.Models
{
  public class Flavors
    {
        public Flavors()
        {
            this.Treats = new HashSet<Treats>();
        }

        public int FlavorsId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<FlavorsTreats> FlavorsTreats { get; set; }
    }
}
