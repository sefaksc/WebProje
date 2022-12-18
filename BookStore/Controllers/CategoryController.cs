using BookStore.Database;
using BookStore.Models;
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
        public IActionResult Create()
        {
           
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category kategori)
        {
            if (ModelState.IsValid)
            {
                _db.Kategori.Add(kategori);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategori);
        }

        public IActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var categoryFromDb = _db.Kategori.FirstOrDefault(k => k.CategoryNo == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category kategori)
        {
            if (ModelState.IsValid)
            {
                _db.Kategori.Update(kategori);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kategori);
        }
    }
}
