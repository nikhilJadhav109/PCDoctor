using Microsoft.AspNetCore.Mvc;
using PCDoctor.Data;
using PCDoctor.Models;

namespace PCDoctor.Controllers
{
    public class CategoryController : Controller
    {
        //Creating Object of ApplicationDbContext class which make connection with Database
        private ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db) 
        { 
            _db = db; 
        }
        public IActionResult Index()
        {   
            //reteriving all categories from database
            List<Category> AllCategories = _db.Categories.ToList();
            return View(AllCategories); //passing List<category> as model to View
        }

        public IActionResult CreateNewCategory() {
            return View();            
        }
        [HttpPost]
        public IActionResult CreateNewCategory(Category obj)
        {   //custom Validations
            if (obj.Name == obj.DisplayOrder.ToString()) {
                ModelState.AddModelError("Name", "Category Name and Display Order Cannot br Same");
            }
            if (ModelState.IsValid)
            {   
                //Added new Createed Object in DataSet
                _db.Categories.Add(obj);
                //Saving Object from dataset in DB
                _db.SaveChanges();
                TempData["sucess"] = "Category Created Successfully";
                return RedirectToAction("Index");   
            }
            return View();
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0) { 
                return NotFound(); //we can also return a error page here
            }

            //reteriving Category object from database having same id as id passed to method
            Category? obj = _db.Categories.FirstOrDefault(o=> o.Id == id); // method 1 works on any column of DB
           // Category? obj1 = _db.Categories.Find(id); // method 2 works on only primary key column of DB
           // Category? obj2 = _db.Categories.Where(o=> o.Id == id).FirstOrDefault(); // method 3 works on any column of DB

            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            
            if (ModelState.IsValid)
            {
                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["sucess"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound(); //we can also return a error page here
            }
            //reteriving Category object from database having same id as id passed to method
            Category? obj = _db.Categories.FirstOrDefault(o => o.Id == id);
            return View(obj);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(obj); 
            _db.SaveChanges();
            TempData["sucess"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }


    }
}
