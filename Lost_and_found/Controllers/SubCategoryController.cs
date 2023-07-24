using BussinesLogic.IService;
using BussinesLogic.Service;
using DataAccess.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lost_and_found.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        ISubCategoryService subCategoryService;
        ILogger<SubCategoryController> _ilogger;
        public SubCategoryController(ISubCategoryService subCategoryService, ILogger<SubCategoryController> _ilogger)
        {
            this.subCategoryService = subCategoryService;
            this._ilogger = _ilogger;
        }
        [HttpGet]
        [Route("Get_subcategory_by_categoryId/{categoryId}")]
        public async Task<List<SubCategoryDTO>> GetSubcategoryByCategoryId(int categoryId)
        {
            try
            {

            List<SubCategoryDTO> categoryList = await subCategoryService.GetSubcategoryByCategoryId(categoryId);
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
