using DataAccess.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.IService
{
    public interface ISubCategoryService
    {
        public Task<List<SubCategoryDTO>> GetSubcategoryByCategoryId(int categoryid);

    }
}
