using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.IService
{
    public interface ICityService
    {
        public Task<List<CityDTO>> GetAllCity();
    }
}
