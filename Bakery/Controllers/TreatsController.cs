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
    public class TreatsController : Controller 
    {
        private readonly BakeryContext _db;
       
        public ActionResult Index () 
        {
            return View();
        }

        public ActionResult Create () 
        {
            ViewBag.CategoryId = new SelectList (_db.Flavors, "FlavorsId", "Name");
            return View ();
        }

        // [HttpPost]
        // public async Task<ActionResult> Create (Item item, int CategoryId) {
        //     var userId = this.User.FindFirst (ClaimTypes.NameIdentifier)?.Value;
        //     var currentUser = await _userManager.FindByIdAsync (userId);
        //     item.User = currentUser;
        //     _db.Items.Add (item);
        //     if (CategoryId != 0) {
        //         _db.CategoryItem.Add (new CategoryItem () { CategoryId = CategoryId, ItemId = item.ItemId });
        //     }
        //     _db.SaveChanges ();
        //     return RedirectToAction ("Index");
        // }
    }
}