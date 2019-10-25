using System.Collections.Generic;
using System;
using BasicAuthentication.Models;

namespace Bakery.Models
{
  public class Flavors
    {
        public Flavors()
        {
            this.Treats = new HashSet<FlavorsTreats>();
        }

        public int FlavorsId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<FlavorsTreats> Treats { get; set; }
    }
}
