using BookStore.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BookStore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _db;

        public CategoryController(AppDbContext db)
        {
            _db = db;   
        }

        public IActionResult Index()
        {
            var CategoryList = _db.Kategori.ToList();
            return View(CategoryList);
        }
    }
}
