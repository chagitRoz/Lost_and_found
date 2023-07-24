using BussinesLogic.IService;
using DataAccess.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lost_and_found.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryService categoryService;
        ILogger<CategoryController> _ilogger;

        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> _ilogger)
        {
            this.categoryService = categoryService;
            this._ilogger = _ilogger;
        }
        [HttpGet]
        [Route("Get_all_category")]
        public async Task<List<CategoryDTO>> GetAllCategory()
        {
            try
            {
            List<CategoryDTO> categoryList = await categoryService.GetAllCategory();
            return categoryList;
            }
            catch (Exception e)
            {
                _ilogger.LogError(e.Message + e.StackTrace);
                throw;
            }

        }

    }
}
