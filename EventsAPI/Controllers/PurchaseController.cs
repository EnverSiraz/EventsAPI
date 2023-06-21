using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers
{
    public class PurchaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
