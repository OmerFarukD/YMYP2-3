using Giris.Data;
using Microsoft.AspNetCore.Mvc;

namespace Giris.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Anasayfa()
        {

            var products = Repository.Products;

            return View(products);
        }
    }
}
