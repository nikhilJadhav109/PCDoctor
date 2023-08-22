using Microsoft.AspNetCore.Mvc;
using PCDoctor.DataAccess.Data;
using PCDoctor.DataAccess.Repository.IRepository;
using PCDoctor.Models.Models;

namespace PCDoctor.Controllers
{
    public class CategoryController : Controller
    {
        //Creating Object of ApplicationDbContext class which make connection with Database
        private ICategoryRepository _CategoryRepo;
        public CategoryController(ICategoryRepository CategoryRepo) 
        {
            _CategoryRepo = CategoryRepo; 
        }
        public IActionResult Index()
        {   
            //reteriving all categories from database
            List<Category> AllCategories = _CategoryRepo.GetAll().ToList();
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
                _CategoryRepo.Add(obj);
                //Saving Object from dataset in DB
                _CategoryRepo.Save();
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
            Category? obj = _CategoryRepo.Get(o=> o.Id == id); // method 1 works on any column of DB
           // Category? obj1 = _db.Categories.Find(id); // method 2 works on only primary key column of DB
           // Category? obj2 = _db.Categories.Where(o=> o.Id == id).FirstOrDefault(); // method 3 works on any column of DB

            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            
            if (ModelState.IsValid)
            {
                _CategoryRepo.Update(obj);
                _CategoryRepo.Save();
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
            Category? obj = _CategoryRepo.Get(o => o.Id == id);
            return View(obj);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = _CategoryRepo.Get(o => o.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _CategoryRepo.Remove(obj);
            _CategoryRepo.Save();
            TempData["sucess"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }


    }
}
