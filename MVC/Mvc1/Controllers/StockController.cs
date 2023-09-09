using Microsoft.AspNetCore.Mvc;

namespace Mvc1.Controllers
{
    public class StockController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
