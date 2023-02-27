using HiringChallenge.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringChallenge.Services.Services.Abstract
{
    public interface IUserCategoryListService
    {
        public List<Category> GetAllCategories();
        public void CreateCategory(Category category);
        public void DeleteCategory(int id);
        public void UpdateCategory(Category category);
        public void GetByCategoryId(int id);
    }
}
