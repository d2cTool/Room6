using Microsoft.AspNetCore.Mvc;

namespace WebApp.Server.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("~/")]
        public ActionResult Index() => View();
    }
}
