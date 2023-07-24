using DataAccess.DBModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.IService
{
    public interface ILostAndFoundService
    {
        public Task<List<LostAndFoundDTO>> GetAllLostsAndFounds();
        public Task<List<LostAndFoundWithNameDTO>> GetAllLostsAndFounds2();
        public Task<List<LostAndFoundDTO>> GetByParams(int TypeId, int CategoryId);
        public Task<List<LostAndFoundWithNameDTO>> GetByAdvancedSearch(int userId = -1, int typeId = -1, int categoryId = -1, int subCategoryId = -1, DateTime? startDatePublished = null, DateTime? endDatePublished = null, DateTime? startDate = null, DateTime? endDate = null, string? common = "defaultValue", string city = "defaultValue");
        public Task<List<LostAndFoundWithNameDTO>> GetAdsByUserId(int userId);
        public Task<LostAndFoundWithCitiesDTO> AddAd(LostAndFoundWithCitiesDTO lf);
        public Task<LostAndFoundWithCitiesDTO> UpdateAd(int adId, LostAndFoundWithCitiesDTO lf);
        public Task UploadFile(int studentId, IFormFile userfile);
        public Task SetPicture(int studentId, string fileName);
    }
}
