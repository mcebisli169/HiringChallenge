using HiringChallenge.Core.Dto;
using HiringChallenge.Core.Entity;
using HiringChallenge.Services.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace HiringChallenge.Web.Controllers
{
    public class UserListController : Controller
    {
        private readonly IUserListService _userListService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        public UserListController(IUserListService userListService,ICategoryService categoryService,IProductService productService)
        {
            _userListService = userListService;
            _categoryService = categoryService;
            _productService = productService;
        
        }
        public IActionResult Index()
        {
            var userLists = _userListService.GetAllLists();
            return View(userLists);
        }
        [HttpGet]
        public IActionResult AddList()
        {
            ViewBag.Category = _categoryService.GetALlCategories();
            return View();
        }
        [HttpPost]
        public IActionResult AddList(UserListCategoryModel userList)
        {
            _userListService.CreateList(userList);
            return View("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var userList = _userListService.GetByUserListId(id);
            return View(userList);
        }
        [HttpPost]
        public IActionResult Edit(UserList userList)
        {
            var UserList = _userListService.GetByUserListId(userList.Id);
            if (userList != null)
            {
                userList.Name = userList.Name;
                userList.ModifiedDate = DateTime.Now;
                userList.CreatedUser = Guid.NewGuid().ToString();
                userList.ListOwner = Guid.NewGuid().ToString();
                userList.ModifiedUser = Guid.NewGuid().ToString();
                _userListService.UpdateList(userList);
            }
            var ul = _userListService.GetAllLists();

            return View("Index",ul);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _userListService.DeleteList(id);
            var ul = _userListService.GetAllLists();
            return View("Index", ul);
        }
    }
}
