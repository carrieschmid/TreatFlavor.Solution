using System.Collections.Generic;
using System.Linq;
using BasicAuthentication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Bakery.Models;

namespace Bakery.Controllers {
    public class FlavorsController : Controller {
        private readonly BakeryContext _db;
        public FlavorsController (BakeryContext db) {
            _db = db;
        }

        public ActionResult Index () {
            List<Flavors> model = _db.Flavors.ToList ();
            return View (model);
        }

        public ActionResult Create () {
            return View ();
        }

        [HttpPost]
        public ActionResult Create (Flavors flavor) {
            _db.Flavors.Add (flavor);
            _db.SaveChanges ();
            return RedirectToAction ("Index");
        }

    }

}