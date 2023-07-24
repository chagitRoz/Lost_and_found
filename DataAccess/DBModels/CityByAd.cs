using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class CityByAd
    {
        public int CityByAdId { get; set; }
        public int CityId { get; set; }
        public int AdId { get; set; }

        public virtual LostAndFound Ad { get; set; } = null!;
        public virtual City City { get; set; } = null!;
    }
}
