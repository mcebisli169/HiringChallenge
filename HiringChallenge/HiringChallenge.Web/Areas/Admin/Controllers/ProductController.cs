using HiringChallenge.Core.Dto;
using HiringChallenge.Core.Entity;
using HiringChallenge.Services.Services.Abstract;
using HiringChallenge.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace HiringChallenge.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        public ProductController(IProductService productService,ICategoryService categoryService)
        {
            _productService = productService;   
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var products = _productService.GetProductListModels();
            return View(products);
        }
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Category = _categoryService.GetALlCategories();
            return View();  
        }
        [HttpPost]
        public IActionResult Add(ProductModel product)
        {
           _productService.Add(product);
            var products = _productService.GetProductListModels();
            return View("Index",products);
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _productService.GetProduct(id);
            return View(product);
        }
        
    }
}
