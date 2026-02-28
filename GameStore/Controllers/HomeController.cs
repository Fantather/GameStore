using GameStore.Interfaces;
using GameStore.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace GameStore.Controllers
{
    //public class HomeController : Controller
    //{
    //    private readonly IProduct _products;

    //    public HomeController(IProduct products)
    //    {
    //        _products = products;
    //    }
    //    [HttpGet]
    //    public IActionResult Index()
    //    {
    //        return View(_products.GetAllProducts());
    //    }
    //    [HttpPost]
    //    public IActionResult AddProduct(Product product)
    //    {
    //        _products.AddProduct(product);
    //        return RedirectToAction(nameof(Index));
    //    }

    //    [HttpGet]
    //    public IActionResult UpdateProduct(int id)
    //    {
    //        return View(_products.GetProduct(id));
    //    }
    //    [HttpPost]
    //    public IActionResult UpdateProduct(Product product)
    //    {
    //        _products.UpdateProduct(product);
    //        return RedirectToAction(nameof(Index));
    //    }

    //    [HttpGet]
    //    public IActionResult UpdateAll()
    //    {
    //        ViewBag.UpdateAll = true;
    //        return View(nameof(Index), _products.GetAllProducts());
    //    }
    //    [HttpPost]
    //    public IActionResult UpdateAll(Product[] products)
    //    {
    //        _products.UpdateAll(products);
    //        return RedirectToAction(nameof(Index));
    //    }

    //    [HttpPost]
    //    public IActionResult DeleteProduct(Product product)
    //    {
    //        _products.DeleteProduct(product);
    //        return RedirectToAction(nameof(Index));
    //    }
    //}


    public class HomeController : Controller
    {
        private readonly IProduct _products;

        public HomeController(IProduct products)
        {
            _products = products;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_products.GetAllProducts());
        }
        [HttpGet]
        public IActionResult UpdateProduct(int id)
        {
            return View(id == 0 ? new Product() : _products.GetProduct(id));
        }
        [HttpPost]
        public IActionResult UpdateProduct(Product product)
        {
            if (product.Id == 0)
            {
                _products.AddProduct(product);
            }
            else
            {
                _products.UpdateProduct(product);
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult DeleteProduct(Product product)
        {
            _products.DeleteProduct(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
