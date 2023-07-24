using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class Status
    {
        public Status()
        {
            LostAndFounds = new HashSet<LostAndFound>();
        }

        public int StatusId { get; set; }
        public string? StatusName { get; set; }

        public virtual ICollection<LostAndFound> LostAndFounds { get; set; }
    }
}
