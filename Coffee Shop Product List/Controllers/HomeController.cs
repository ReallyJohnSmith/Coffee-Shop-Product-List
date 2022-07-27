using Coffee_Shop_Product_List.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Coffee_Shop_Product_List.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CoffeeShopProductContext _CoffeeShopProductContext;

        public HomeController(ILogger<HomeController> logger, CoffeeShopProductContext newCoffeeShopProductContext)
        {
            _logger = logger;
            _CoffeeShopProductContext = newCoffeeShopProductContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult DisplayMyProducts()
        {
            var products = _CoffeeShopProductContext.Products.ToArray();
            return View(products);
        }

        public IActionResult MyProductDetails(int ID)
        {
            Products foundProduct = null;
            foreach (var currProduct in _CoffeeShopProductContext.Products.ToArray())
            {
                if (currProduct.ID == ID)
                {
                    foundProduct = currProduct;
                    break;
                }
            }
            return View(foundProduct);
        }





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}