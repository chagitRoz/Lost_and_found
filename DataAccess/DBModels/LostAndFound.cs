using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class LostAndFound
    {
        public LostAndFound()
        {
            CityByAds = new HashSet<CityByAd>();
        }

        public int Id { get; set; }
        public int TypeId { get; set; }
        public int StatusId { get; set; }
        public int UserId { get; set; }
        public int? CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public DateTime? DatePublished { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Common { get; set; }
        public bool? GetEmail { get; set; }
        public string? Image { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Status Status { get; set; } = null!;
        public virtual SubCategory? SubCategory { get; set; }
        public virtual Type Type { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<CityByAd> CityByAds { get; set; }
    }
}
