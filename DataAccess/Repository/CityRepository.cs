using DataAccess.DBModels;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class CityRepository : ICityRepository
    {
        LfDBContext _dBContext;
        public CityRepository(LfDBContext _dBContext)
        {
            this._dBContext = _dBContext;
        }

        public async Task<List<City>> GetAllCity()
        {
            List<City> cityList = await _dBContext.Cities.OrderBy(d => d.CityName).ToListAsync();
            return cityList;
        }
    }
}
