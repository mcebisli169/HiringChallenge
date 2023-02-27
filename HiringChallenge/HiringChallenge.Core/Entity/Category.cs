using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringChallenge.Core.Entity
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public List<ProductCategory> ProductCategories { get; set; }
        public List<UserCategoryList> UserCategoryLists { get; set; }
    }
}
