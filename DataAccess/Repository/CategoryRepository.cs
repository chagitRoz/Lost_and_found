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
    public class CategoryRepository: ICategoryRepository
    {
        LfDBContext _dBContext;
        public CategoryRepository(LfDBContext _dBContext)
        {
            this._dBContext = _dBContext;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            List<Category> CategoryList = await _dBContext.Categories.ToListAsync();
            return CategoryList;
        }
    }
}
