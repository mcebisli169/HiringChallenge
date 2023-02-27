using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringChallenge.Core.Entity
{
    public class UserCategoryList:BaseEntity
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public int UserListId { get; set; }
        public UserList UserList { get; set; }
    }
}
