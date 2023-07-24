using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class City
    {
        public City()
        {
            CityByAds = new HashSet<CityByAd>();
        }

        public int CityId { get; set; }
        public string CityName { get; set; } = null!;

        public virtual ICollection<CityByAd> CityByAds { get; set; }
    }
}
