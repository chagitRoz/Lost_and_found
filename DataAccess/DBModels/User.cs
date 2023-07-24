using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class User
    {
        public User()
        {
            LostAndFounds = new HashSet<LostAndFound>();
        }

        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public virtual ICollection<LostAndFound> LostAndFounds { get; set; }
    }
}
