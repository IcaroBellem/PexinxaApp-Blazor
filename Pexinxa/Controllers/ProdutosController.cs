using Microsoft.AspNetCore.Mvc;

namespace Pexinxa.Controllers
{
    public class ProdutosController : Controller
    {
        public IActionResult Produtos()
        {
            return View();
        }
    }
}
