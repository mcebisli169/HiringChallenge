using HiringChallenge.Core.Entity;
using HiringChallenge.Services.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HiringChallenge.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var categories = _categoryService.GetALlCategories();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _categoryService.GetByCategoryId(id);
            return View(category);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _categoryService.DeleteCategory(id);
            var categories = _categoryService.GetALlCategories();
            return View("Index", categories);
        }
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            var tempCategory = _categoryService.GetByCategoryId(category.Id);
            if (tempCategory!=null)
            {
                tempCategory.Name = category.Name;
                tempCategory.ModifiedDate = DateTime.Now;
                _categoryService.UpdateCategory(tempCategory);
            }
            var categories = _categoryService.GetALlCategories();
            return View("Index", categories);
        }
        [HttpPost]
        public IActionResult Add(Category category)
        {
            _categoryService.CreateCategory(category);
            var categories = _categoryService.GetALlCategories();
            return View("Index", categories);
        }
        
    }
}
