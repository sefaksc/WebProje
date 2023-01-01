using BookStore.Database;
using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace BookStore.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _db;

        public HomeController(ILogger<HomeController> logger,AppDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        public IActionResult Index()
        {
            List<Product> products = _db.Urunler.ToList();
            return View(products);
        }

        public IActionResult Details(int Productid)
        {
            ShoppingCart cart = new()
            {
                count = 1,
                ProductId = Productid,
                product = _db.Urunler.FirstOrDefault(u => u.Id == Productid)
            };
            return View(cart);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult Details(ShoppingCart shoppingcart)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            shoppingcart.AppUserId = claim.Value;
            _db.ShoppingCart.Add(shoppingcart);          
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}