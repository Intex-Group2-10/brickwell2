using brickwell2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using brickwell2.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.Elfie.Model.Tree;
using System.Drawing.Printing;

namespace brickwell2.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private ILegoRepository _repo;
        public HomeController(ILegoRepository temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            var viewStuff = _repo.Products.ToList();
            return View(viewStuff);
        }


        public IActionResult Privacy()
        {
            return View();
        }
        
        public IActionResult About()
        {
            return View();
        }
        
        public IActionResult Cart()
        {
            return View();
        }
        
        public IActionResult Checkout()
        {
            return View();
        }
        
        public IActionResult ProductDetail()
        {
            return View();
        }
        
        public IActionResult Products(int pageNum)
        {
            return View();
        }
        public IActionResult Profile()
        {
            return View();
        }

            int pageSize = 3;

            var productData = _repo.Products;

            return View(productData);
        }
    }
}
