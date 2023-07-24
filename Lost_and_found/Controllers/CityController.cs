using BussinesLogic.IService;
using DataAccess.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Lost_and_found.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        ICityService cityService;
        ILogger<CityController> _ilogger;
        public CityController(ICityService cityService, ILogger<CityController> _ilogger)
        {
            this.cityService = cityService;
            this._ilogger = _ilogger;
        }
        [HttpGet]
        [Route("GetAllCity")]
        public async Task<List<CityDTO>> GetAllCity()
        {
            try
            {
            List<CityDTO> cityList = await cityService.GetAllCity();
            return cityList;
            }
            catch (Exception e)
            {
                _ilogger.LogError(e.Message + e.StackTrace);
                throw;
            }

        }
    }
}
