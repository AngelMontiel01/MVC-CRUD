using Microsoft.AspNetCore.Mvc;

namespace ETIGRTEC.Controllers
{
    public class ProductsViewController : Controller
    {
        public IActionResult Index()
        {
            return View(); // Asegúrate de que exista una vista "Index.cshtml" en la carpeta "Views/ProductsView"
        }
    }
}
