using Microsoft.AspNetCore.Mvc;
using PCDoctor.Data;
using PCDoctor.Models;

namespace PCDoctor.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) 
        { 
            _db = db; 
        }
        public IActionResult Index()
        {   
            List<Category> AllCategories = _db.Categories.ToList();
            return View(AllCategories);
        }

        public IActionResult CreateNewCategory() {
            return View();            
        }
        [HttpPost]
        public IActionResult CreateNewCategory(Category obj)
        {   
            if (obj.Name == obj.DisplayOrder.ToString()) {
                ModelState.AddModelError("Name", "Category Name and Display Order Cannot br Same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");   
            }
            return View();
        }

    }
}
