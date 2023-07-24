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
    public class SubCategoryRepository : ISubCategoryRepository
    {

        LfDBContext dBContext;
        public SubCategoryRepository(LfDBContext dBContext)
        {
            this.dBContext = dBContext;
        }

        public async Task<List<SubCategory>> GetSubcategoryByCategoryId(int categoryid)
        {
            try
            {
                List<SubCategory> subCategoryList =await dBContext.SubCategories.Where(x => x.CategoryId == categoryid).ToListAsync();
                if (subCategoryList.Count == 0)
                    return null;
                return subCategoryList;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in Get subcategory by categoryId function" + ex.Message);

            }
        }
    }
}
