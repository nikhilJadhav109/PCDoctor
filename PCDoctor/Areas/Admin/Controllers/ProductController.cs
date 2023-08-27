using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PCDoctor.DataAccess.Repository.IRepository;
using PCDoctor.Models.Models;
using PCDoctor.Models.Models.ViewModels;

namespace PCDoctor.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        //Creating Object of ApplicationDbContext class which make connection with Database
        private IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IUnitOfWork _UnitOfWork, IWebHostEnvironment _WebHostEnvironment)
        {
            _unitOfWork = _UnitOfWork;
            _webHostEnvironment = _WebHostEnvironment;
        }
        public IActionResult Index()
        {
            //reteriving all categories from database
            List<Product> AllProduct = _unitOfWork.Product.GetAll().ToList();
            return View(AllProduct); //passing List<category> as model to View
        }



        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                CategoryList = _unitOfWork.Category.GetAll().Select(obj => new SelectListItem
                {
                    Text = obj.Name,
                    Value = obj.Id.ToString()

                }),
                Product = new Product(),

            };
            if (id == null || id == 0)
            {
                //Create
                return View(productVM);
            }
            else
            {
                //Update
                productVM.Product = _unitOfWork.Product.Get(o => o.Id == id); // Getting a single product from DB of Selected Id
                return View(productVM);
            }

        }

        [HttpPost]
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                //gettint root folder path
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\products");
                    if (!string.IsNullOrEmpty(obj.Product.ImageUrl))
                    {
                        //delete old Image path
                        var oldPath = Path.Combine(wwwRootPath, obj.Product.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldPath))
                        {
                            System.IO.File.Delete(oldPath);
                        }
                    }
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    obj.Product.ImageUrl = @"\images\products\" + fileName;
                }

                if (obj.Product.Id == 0)
                {
                    //Added new Createed Object in DataSet
                    _unitOfWork.Product.Add(obj.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(obj.Product);
                }


                //Saving Object from dataset in DB
                _unitOfWork.Save();
                TempData["sucess"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }
            return View();
        }


        /*public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound(); //we can also return a error page here
            }

            //reteriving Category object from database having same id as id passed to method
            Product? obj = _unitOfWork.Product.Get(o => o.Id == id); // Getting a single product from DB of Selected Id
                                                                      

            return View(obj);
        }*/

        /*[HttpPost]
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
*/
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
