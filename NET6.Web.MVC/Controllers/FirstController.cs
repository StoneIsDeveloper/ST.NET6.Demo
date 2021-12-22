using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NET6.Web.MVC.Controllers
{
    public class FirstController : Controller
    {
        // GET: FirstController
        public ActionResult Index()
        {

            ViewBag.User1 = "1Tom";
            ViewData["User2"] = "2Jack";
            TempData["User3"] = "3Lucy";
            HttpContext.Session.SetString("User4", "4Kay");
            object User5 = "5King";
            return View();
        }

    }
}
