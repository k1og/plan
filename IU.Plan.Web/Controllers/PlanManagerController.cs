using Microsoft.AspNetCore.Mvc;

namespace IU.Plan.Web.Controllers
{
    public class PlanManagerController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}