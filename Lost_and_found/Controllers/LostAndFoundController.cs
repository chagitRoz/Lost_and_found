using BussinesLogic.IService;
using BussinesLogic.Service;
using DataAccess.DBModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lost_and_found.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LostAndFoundController : ControllerBase
    {

        ILostAndFoundService lostAndFoundService;
        ILogger<LostAndFoundController> _ilogger;

        public LostAndFoundController(ILostAndFoundService lostAndFoundService, ILogger<LostAndFoundController> _ilogger)
        {
            this.lostAndFoundService = lostAndFoundService;
            this._ilogger = _ilogger;
        }
        [HttpGet]
        [Route("GetAllLostsAndFounds")]

        public async Task<List<LostAndFoundDTO>> GetAllLostsAndFounds()
        {
            try
            {
                List<LostAndFoundDTO> lostAndFoundDTOList = await lostAndFoundService.GetAllLostsAndFounds();
                return lostAndFoundDTOList;
            }
            catch (Exception e)
            {
                _ilogger.LogError(e.Message + e.StackTrace);
                throw;
            }
        }
        [HttpGet]
        [Route("GetAllLostsAndFounds2")]

        public async Task<List<LostAndFoundWithNameDTO>> GetAllLostsAndFounds2()
        {
            try
            {
                return await lostAndFoundService.GetAllLostsAndFounds2();
            }
            catch (Exception e)
            {
                _ilogger.LogError(e.Message + e.StackTrace);
                throw;
            }
        }
        [HttpGet]
        [Route("GetByParams")]

        public async Task<ActionResult<List<LostAndFoundDTO>>> GetByParams(int TypeId = -1, int CategoryId = -1)
        {
            try
            {
                List<LostAndFoundDTO> lostAndFoundDTOList = await lostAndFoundService.GetByParams(TypeId, CategoryId);
                return lostAndFoundDTOList;
            }
            catch (Exception e)
            {
                _ilogger.LogError(e.Message + e.StackTrace);
                throw;
            }
        }
        [HttpGet]
        [Route("GetByAdvancedSearch")]

            public async Task<ActionResult<List<LostAndFoundWithNameDTO>>> GetByAdvancedSearch(int userId= -1,int typeId = -1, int categoryId = -1, int subCategoryId = -1, DateTime? startDatePublished = null,DateTime? endDatePublished=null, DateTime? startDate = null, DateTime? endDate = null, string? common = "defaultValue", string city = "defaultValue")

        {
            try
            {
            List<LostAndFoundWithNameDTO> lostAndFoundDTOList = await lostAndFoundService.GetByAdvancedSearch(userId,typeId, categoryId, subCategoryId, startDatePublished, endDatePublished, startDate, endDate, common,city);
            if (lostAndFoundDTOList.Count > 0)
            {
                    Console.WriteLine("got data");
                return Ok(lostAndFoundDTOList);
            }
                Console.WriteLine("no data");

                return NotFound();
            }
            catch (Exception e)
            {
                Console.WriteLine("error");

                _ilogger.LogError(e.Message + e.StackTrace);
                throw;
            }

        }
        [HttpGet]
        [Route("GetAdsByUserId")]
        public async Task<List<LostAndFoundWithNameDTO>> GetAdsByUserId(int userId)
        {
            try
            {
                List<LostAndFoundWithNameDTO> lfDto = await lostAndFoundService.GetAdsByUserId(userId);
                return lfDto;
            }
            catch (Exception e)
            {
                _ilogger.LogError(e.Message + e.StackTrace);
                throw;
            }
        }

        [HttpPost]
        [Route("AddAd")]
        public async Task<LostAndFoundWithCitiesDTO> AddAd(LostAndFoundWithCitiesDTO lf)
        {
            LostAndFoundWithCitiesDTO lfDto;
            try
            {
                lfDto = await lostAndFoundService.AddAd(lf);
                //string filename = userfile.FileName;
                //filename = Path.GetFileName(filename);
                //string uploadFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", filename);
                //await using var stream = new FileStream(uploadFilePath, FileMode.Create);
                //await userfile.CopyToAsync(stream);
                //SetPicture(lfDto.Id, userfile.FileName);
                return lfDto;
            }
            catch (Exception e)
            {
                _ilogger.LogError(e.Message + e.StackTrace);
                throw;
            }
            
        }
        [HttpPost, Route("UploadImage")]
        public async Task UploadFile(int lfId, IFormFile userfile)
        {

            try
            {
                lostAndFoundService.UploadFile(lfId, userfile);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            try
            {

                string filename = userfile.FileName;
                filename = Path.GetFileName(filename);
                string uploadFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", filename);
                await using var stream = new FileStream(uploadFilePath, FileMode.Create);
                await userfile.CopyToAsync(stream);
                SetPicture(lfId, userfile.FileName);
                


                //string filename = userfile.FileName;
                //filename = Path.GetFileName(filename);
                //string uploadFilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", filename);
                //await using var stream = new FileStream(uploadFilePath, FileMode.Create);
                //await userfile.CopyToAsync(stream);
                //SetPicture(lfId, userfile.FileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        [HttpPut]
        [Route("UpdateAd")]
        public async Task<LostAndFoundWithCitiesDTO> UpdateAd(int adId,LostAndFoundWithCitiesDTO lf)
        {
            try
            {
                LostAndFoundWithCitiesDTO lfDto = await lostAndFoundService.UpdateAd(adId,lf);
            return lfDto;
            }
            catch (Exception e)
            {
                _ilogger.LogError(e.Message + e.StackTrace);
                throw;
            }
        }
        
        [HttpPut("SetPicture")]

        public Task SetPicture(int lfId, string Filename)
        {
            return lostAndFoundService.SetPicture(lfId, Filename);
        }
    }
}
