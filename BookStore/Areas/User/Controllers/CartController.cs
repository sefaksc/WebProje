using BookStore.Database;
using BookStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BookStore.Areas.User.Controllers
{
    [Area("User")]
    [Authorize]
    public class CartController : Controller
    {
        private readonly AppDbContext _db;

        public int Total;

        public CartController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {   double total = 0;
            List<ShoppingCart> carts = _db.ShoppingCart.Include(u=>u.product).ToList();
            foreach (ShoppingCart cart in carts)
            {
                cart.PriceTotal += (cart.product.Price * cart.count);
                total += cart.PriceTotal;
            }
            TempData["Total"] = total;
            return View(carts);
        }

        public IActionResult Remove(int cartId)
        {
            double total = 0;
            var cart2 = _db.ShoppingCart.FirstOrDefault(u => u.Id == cartId);
            _db.ShoppingCart.Remove(cart2);
            _db.SaveChanges();
            List<ShoppingCart> carts = _db.ShoppingCart.Include(u => u.product).ToList();
            return RedirectToAction(nameof(Index));
        }
    }
}
