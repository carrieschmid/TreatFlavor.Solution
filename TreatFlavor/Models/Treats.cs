using System;
using System.Collections.Generic;

namespace Bakery.Models
{
  public class Treats
  {
    public Treats()
    {
        this.Flavors = new HashSet<FlavorsTreats>();
    }
    public int TreatsId { get; set; }
    public string Name { get; set; }
    public int FlavorsId { get; set; }
     public ICollection<FlavorsTreats> Flavors { get; }
  }


}