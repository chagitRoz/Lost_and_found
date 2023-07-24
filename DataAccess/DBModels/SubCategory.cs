using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            LostAndFounds = new HashSet<LostAndFound>();
        }

        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; } = null!;
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual ICollection<LostAndFound> LostAndFounds { get; set; }
    }
}
