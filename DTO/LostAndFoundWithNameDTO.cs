
using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class LostAndFoundWithNameDTO
    {
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
        public string? Image { get; set; }
        public bool? GetEmail { get; set; }
        public string SubCategoryName { get; set; }

        public string TypeName { get; set; }
        public List<string> Cities{ get; set; } 


    }
}
