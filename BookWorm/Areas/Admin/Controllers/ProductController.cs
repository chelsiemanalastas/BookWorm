using Book.DataAccess;
using Book.DataAccess.Repository;
using Book.DataAccess.Repository.IRepository;
using Book.Models;
using Book.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookWorm.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unit;
        private readonly IWebHostEnvironment _webHostEnv;
        public ProductController(IUnitOfWork unit, IWebHostEnvironment webHostEnv)
        {
            _unit = unit;
            _webHostEnv = webHostEnv;
        }

        public IActionResult Index()
        {
            List<Product> ProductList = _unit.Product.GetAll(includeProp:"Category").ToList();
            return View(ProductList);
        }

        public IActionResult Upsert(int? id)
        {
            ProductVM productVM = new()
            {
                CategoryList = _unit.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),
                Product = new Product()
            };
            if (id == null|| id == 0) //CREATE
            {
                return View(productVM);
            }
            else //UPDATE 
            {
                productVM.Product = _unit.Product.Get(u=>u.Id == id);
                return View(productVM);
            }
        }

        [HttpPost]
        public IActionResult Upsert(ProductVM obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string imagePath = @"images\product";
                string wwwRootPath = _webHostEnv.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, imagePath);

                    if (!string.IsNullOrEmpty(obj.Product.ImageUrl)) // remove existing image
                    {
                        var oldImage = Path.Combine(wwwRootPath, obj.Product.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImage))
                        {
                            System.IO.File.Delete(oldImage);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    obj.Product.ImageUrl = $"\\{imagePath}\\{fileName}";
                }

                if (obj.Product.Id == 0)
                {
                    _unit.Product.Add(obj.Product);
                    TempData["success"] = "Product created successfully";
                }
                else
                {
                    _unit.Product.Update(obj.Product);
                    TempData["success"] = "Product updated successfully";
                }

                _unit.Save();
                return RedirectToAction("Index");
            }
            else
            {
                obj.CategoryList = _unit.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                });
                return View(obj);
            }
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product product = _unit.Product.Get(c => c.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            ProductVM productVM = new()
            {
                CategoryList = _unit.Category.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString(),
                }),
                Product = product
            };
            return View(productVM);
        }

        [HttpPost]
        public IActionResult Edit(Product obj)
        {
            if (ModelState.IsValid)
            {
                _unit.Product.Update(obj);
                _unit.Save();
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index");
            }
            return View();
        }

        #region API REQUESTS

        [HttpGet]
        public IActionResult GetAll() 
        {
            List<Product> ProductList = _unit.Product.GetAll(includeProp: "Category").ToList();
            return Json(new {data = ProductList});
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var productToDelete = _unit.Product.Get(u=>u.Id == id);
            if (productToDelete == null)
            {
                return Json(new { success = false, message = "Error encountered while deleting" });
            }

            var oldImage = Path.Combine(_webHostEnv.WebRootPath, productToDelete.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImage))
            {
                System.IO.File.Delete(oldImage);
            }

            _unit.Product.Remove(productToDelete);
            _unit.Save();

            return Json(new { success = true, message = "Product deleted successfully" });

        }

        #endregion
    }
}
