using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class Type
    {
        public Type()
        {
            LostAndFounds = new HashSet<LostAndFound>();
        }

        public int TypeId { get; set; }
        public string TypeName { get; set; } = null!;

        public virtual ICollection<LostAndFound> LostAndFounds { get; set; }
    }
}
