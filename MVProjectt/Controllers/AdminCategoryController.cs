using Microsoft.AspNetCore.Mvc;

namespace MVProjectt.Controllers
{
    public class AdminCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
