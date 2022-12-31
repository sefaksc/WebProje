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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(AppDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var UrunlerList = _db.Urunler.ToList();
            return View(UrunlerList);
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
                ViewBag.Kategoriler = CategoryList;
                var urunfromdb = _db.Urunler.FirstOrDefault(k => k.Id == id);
                return View(urunfromdb);
            }
      
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Product urun, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwRootPath, @"Images\Products");
                    var extension = Path.GetExtension(file.FileName);

                    if(urun.ImageUrl != null)
                    {
                        var oldImagePath = Path.Combine(wwRootPath, urun.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    urun.ImageUrl = @"\Images\Products\" + fileName + extension;
                }
                if(urun.Id == 0)
                {
                    _db.Urunler.Add(urun);
                    TempData["success"] = "Ürün başarıyla eklendi.";
                }
                else
                {
                    _db.Urunler.Update(urun);
                    TempData["success"] = "Ürün başarıyla güncellendi.";
                }
                _db.SaveChanges();
                
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
            var urunFromDB = _db.Urunler.FirstOrDefault(k => k.Id == id);
            if (urunFromDB == null)
            {
                return NotFound();
            }
            return View(urunFromDB);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.Urunler.Find(id);
            var oldImagePath = Path.Combine(_webHostEnvironment.WebRootPath, obj.ImageUrl.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }
            _db.Urunler.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Ürün başarıyla silindi.";
            return RedirectToAction("Index");

        }
    }
}
