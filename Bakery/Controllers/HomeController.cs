using Microsoft.AspNetCore.Mvc;
using BasicAuthentication.Models;

namespace Bakery.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}