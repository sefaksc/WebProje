using BookStore.Database;
using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace BookStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _db;

        public ProductController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var CategoryList = _db.Kategori.ToList();
            return View(CategoryList);
        }

        public IActionResult Upsert(int? id)
        {
            Product urun = new Product();
            IEnumerable<SelectListItem> CategoryList =_db.Kategori.ToList().Select(
                u => new SelectListItem
                {
                    Text =u.Name,
                    Value = u.Id.ToString(),    
                });

            if (id == null)
            {
                ViewBag.Kategoriler = CategoryList;
                return View(urun);
            }
            else
            {

            }
            
            return View(urun);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Product urun, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                //_db.Kategori.Update(kategori);
                _db.SaveChanges();
                TempData["success"] = "Kategori başarıyla güncellendi.";
                return RedirectToAction("Index");
            }
            return View(urun);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Kategori.FirstOrDefault(k => k.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Kategori.Find(id);
            _db.Kategori.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Kategori başarıyla silindi.";
            return RedirectToAction("Index");

        }
    }
}
