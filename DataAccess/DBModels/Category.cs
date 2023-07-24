using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class Category
    {
        public Category()
        {
            LostAndFounds = new HashSet<LostAndFound>();
            SubCategories = new HashSet<SubCategory>();
        }

        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        public virtual ICollection<LostAndFound> LostAndFounds { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
