using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public class SubCategoryDTO { 

        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; } = null!;
        public int CategoryId { get; set; }

    }
}
