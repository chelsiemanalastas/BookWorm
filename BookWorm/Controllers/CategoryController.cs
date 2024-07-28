using BookWorm.Data;
using BookWorm.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookWorm.Controllers
{
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context) 
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Category> categoryList = _context.Categories.ToList();
            return View(categoryList);
        }
    }
}
