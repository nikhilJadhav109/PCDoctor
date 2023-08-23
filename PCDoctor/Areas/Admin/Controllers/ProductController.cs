using Microsoft.AspNetCore.Mvc;
using PCDoctor.DataAccess.Repository.IRepository;
using PCDoctor.Models.Models;

namespace PCDoctor.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        //Creating Object of ApplicationDbContext class which make connection with Database
        private IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork _UnitOfWork)
        {
            _unitOfWork = _UnitOfWork;
        }
        public IActionResult Index()
        {
            //reteriving all categories from database
            List<Product> AllCategories = _unitOfWork.Product.GetAll().ToList();
            return View(AllCategories); //passing List<category> as model to View
        }



        public IActionResult CreateNewProduct()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewProduct(Product obj)
        {               
            if (ModelState.IsValid)
            {
                //Added new Createed Object in DataSet
                _unitOfWork.Product.Add(obj);
                //Saving Object from dataset in DB
                _unitOfWork.Save();
                TempData["sucess"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound(); //we can also return a error page here
            }

            //reteriving Category object from database having same id as id passed to method
            Product? obj = _unitOfWork.Product.Get(o => o.Id == id); // Getting a single product from DB of Selected Id
                                                                      

            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save();
                TempData["sucess"] = "Product Updated Successfully";
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
            //reteriving Product object from database having same id as id passed to method
            Product? obj = _unitOfWork.Product.Get(o => o.Id == id);
            return View(obj);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _unitOfWork.Product.Get(o => o.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["sucess"] = "Product Deleted Successfully";
            return RedirectToAction("Index");
        }




    }
}
