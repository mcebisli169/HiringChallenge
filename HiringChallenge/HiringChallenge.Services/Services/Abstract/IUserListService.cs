using HiringChallenge.Core.Dto;
using HiringChallenge.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringChallenge.Services.Services.Abstract
{
    public interface IUserListService
    {
        public void CreateList(UserListCategoryModel userList);
        public List<UserList> GetAllLists();
        public void UpdateList(UserList userList);
        public UserList GetByUserListId(int id);
        public void DeleteList(int id); 
        public List<Category> GetAllCategories();
        public List<Product> GetAllProducts();
        public void DeleteProduct(int id);
        public void UpdateProduct(Product product);
        public Product GetProduct(int id);
        public void DeleteCategory(int id);
        public void UpdateCategory(Category category);
        public Category GetCategory(int id);

    }
}
