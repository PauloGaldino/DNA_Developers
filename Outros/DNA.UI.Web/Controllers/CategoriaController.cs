using Microsoft.AspNetCore.Mvc;

namespace DNA.UI.Web.Controllers
{
    public class CategoriaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}