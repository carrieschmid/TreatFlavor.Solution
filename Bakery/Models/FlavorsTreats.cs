using System;
using System.Collections.Generic;
using BasicAuthentication.Models;

namespace Bakery.Models
{
  public class FlavorsTreats
    {       
        public int FlavorsTreatsId { get; set; }
        public int TreatsId { get; set; }
        public int FlavoraId { get; set; }
        public Treats Treats { get; set; }
        public Flavors Flavors { get; set; }
    }
}