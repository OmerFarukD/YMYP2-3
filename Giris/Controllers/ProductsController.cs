using Giris.Data;
using Giris.Models;
using Microsoft.AspNetCore.Mvc;

namespace Giris.Controllers;

public class ProductsController : Controller
{
    public IActionResult Anasayfa()
    {

        var products = Repository.Products.OrderBy(x=>x.Id).ToList();

        return View(products);
    }


    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Add(Product product)
    {
        // 1 , 2 , 3 

        int maxId = Repository.Products.Max(x=>x.Id);

        product.Id = ++maxId;

        Repository.Products.Add(product);
        return RedirectToAction("Anasayfa","Products");
    }



    //http://localhost:5045/products/detail/2

    [HttpGet]
    public IActionResult Detail(int id)
    {
        Product product = Repository.Products.SingleOrDefault(p=> p.Id==id);

        return View(product);
    }

    public IActionResult ProductNameContains(string productName)
    {

        //1. Yöntem
        // List<Product> filteredProducts = Repository.Products.FindAll(x=>x.Name==productName);

        List<Product> products = Repository.Products;
        List<Product> filteredProducts = new();

        foreach(Product product in products)
        {
            if (product.Name.Contains(productName,StringComparison.CurrentCultureIgnoreCase))
            {
                filteredProducts.Add(product);
            }
        }


        return View(filteredProducts);

    }


    [HttpGet]
    public IActionResult Update(int id)
    {
        Product product = Repository.Products.SingleOrDefault(x=>x.Id==id);
        return View(product);
    }


    [HttpPost]
    public IActionResult Update(Product product)
    {
        Product deleted = Repository.Products.SingleOrDefault(p => p.Id == product.Id);
        Repository.Products.Remove(deleted);

        Repository.Products.Add(product);

        return RedirectToAction("Anasayfa","Products");
    }


    [HttpGet]
    public IActionResult Delete(int id)
    {
        Product deleted = Repository.Products.SingleOrDefault(p => p.Id == id);
        Repository.Products.Remove(deleted);
        return RedirectToAction("Anasayfa", "Products");
    }


}


