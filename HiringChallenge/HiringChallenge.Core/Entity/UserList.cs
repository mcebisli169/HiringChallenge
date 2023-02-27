using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringChallenge.Core.Entity
{
    public class UserList : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CompletedDate { get; set; }
        public string ListOwner { get; set; }

        public List<UserCategoryList> UserCategoryLists { get; set; }
    }
}
