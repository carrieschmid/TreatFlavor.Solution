using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BasicAuthentication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bakery.Models;

namespace Bakery.Controllers {

    [Authorize]
    public class TreatsController : Controller {
        private readonly BakeryContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public TreatsController (UserManager<ApplicationUser> userManager, BakeryContext db) {
            _userManager = userManager;
            _db = db;
        }

        public async Task<ActionResult> Index () {
            var userId = this.User.FindFirst (ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync (userId);
            var userTreats = _db.Treats.Where (entry => entry.User.Id == currentUser.Id);
            return View (userTreats);
        }

        public ActionResult Create () {
            ViewBag.FlavorsId = new SelectList (_db.Flavors, "FlavorsId", "Name");
            return View ();
        }

        [HttpPost]
        public async Task<ActionResult> Create (Treats treats, int FlavorsId) {
            var userId = this.User.FindFirst (ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync (userId);
            treats.User = currentUser;
            _db.Treats.Add (treats);
            if (FlavorsId != 0) {
                _db.FlavorsTreats.Add (new FlavorsTreats () { FlavorsId = FlavorsId, TreatsId = treats.TreatsId });
            }
            _db.SaveChanges ();
            return RedirectToAction ("Index");
        }

        public ActionResult Details (int id) {

            var thisTreat = _db.Treats
                .Include (treat => treat.Flavors)
                .ThenInclude (join => join.Flavors)
                .FirstOrDefault (treat => treat.TreatsId == id);
            return View (thisTreat);
        }

        public ActionResult Edit (int id) {
            var thisTreat = _db.Items.FirstOrDefault (treats => treats.TreatsId == id);
            ViewBag.FlavorsId = new SelectList (_db.Flavors, "FlavorsId", "Name");
            return View (thisTreat);
        }

        [HttpPost]
        public ActionResult Edit (Treats treats, int FlavorsId) {
            if (FlavorsId != 0) {
                _db.FlavorsTreats.Add (new FlavorsTreats () { FlavorsId = FlavorsId, TreatsId = treats.TreatsId });
            }
            _db.Entry (treats).State = EntityState.Modified;
            _db.SaveChanges ();
            return RedirectToAction ("Index");
        }
        public ActionResult AddFlavors (int id) {
            var thisTreat = _db.Treats.FirstOrDefault (treats => treats.TreatsId == id);
            ViewBag.FlavorsId = new SelectList (_db.Flavors, "FlavorsId", "Name");
            return View (thisTreat);
        }

        [HttpPost]
        public ActionResult AddFlavors (Treats treats, int FlavorsId) {
            if (FlavorsId != 0) {
                _db.FlavorsTreats.Add (new FlavorsTreats () { FlavorsId = FlavorsId, TreatsId = treats.TreatsId });
            }
            _db.SaveChanges ();
            return RedirectToAction ("Index");
        }

        public ActionResult Delete (int id) {
            var thisTreat = _db.Treats.FirstOrDefault (treats => treats.TreatsId == id);
            return View (thisTreat);
        }

        [HttpPost, ActionName ("Delete")]
        public ActionResult DeleteConfirmed (int id) {
            var thisTreat = _db.Treats.FirstOrDefault (treats => treats.TreatsId == id);
            _db.Treats.Remove (thisTreat);
            _db.SaveChanges ();
            return RedirectToAction ("Index");
        }

        [HttpPost]
        public ActionResult DeleteFlavors (int joinId) {
            var joinEntry = _db.FlavorsTreats.FirstOrDefault (entry => entry.FlavorsTreatsId == joinId);
            _db.FlavorsTreats.Remove (joinEntry);
            _db.SaveChanges ();
            return RedirectToAction ("Index");
        }


    }
}