﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringChallenge.Core.Dto
{
    public class UserListCategoryModel
    {
        public string Name { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
