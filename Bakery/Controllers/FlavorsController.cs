using System.Collections.Generic;
using System.Linq;
using Bakery.Models;
using BasicAuthentication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public ActionResult Create (Flavors flavors) {
            _db.Flavors.Add (flavors);
            _db.SaveChanges ();
            return RedirectToAction ("Index");
        }

        public ActionResult Details (int id) 
        {
            var thisFlavor = _db.Flavors
                .Include (flavor => flavor.Treats)
                .ThenInclude (join => join.Treats)
                .FirstOrDefault (flavor => flavor.FlavorsId == id);
            return View (thisFlavor);
        }

    }

}