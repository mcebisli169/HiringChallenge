using HiringChallenge.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HiringChallenge.Services.Services.Abstract
{
    public interface ICategoryService
    {
        public List<Category> GetALlCategories();
        public void CreateCategory(Category category);
        public void DeleteCategory(int id);
        public void UpdateCategory(Category category);
        public Category GetByCategoryId(int id);

    }
}
