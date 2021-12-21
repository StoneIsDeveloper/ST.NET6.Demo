using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NET6.Web.MVC.Controllers
{
    public class FirstController : Controller
    {
        // GET: FirstController
        public ActionResult Index()
        {
            return View();
        }


    }
}
