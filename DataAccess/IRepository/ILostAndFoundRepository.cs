using DataAccess.DBModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.IRepository
{
    public interface ILostAndFoundRepository
    {
        public Task<List<LostAndFound>> GetAllLostsAndFounds();
        public Task<List<LostAndFoundWithNameDTO>> GetAllLostsAndFounds2();
        public Task<List<LostAndFound>> GetByParams(int TypeId, int CategoryId);
        public Task<List<LostAndFoundWithNameDTO>> GetByAdvancedSearch(int userId=-1,int typeId = -1, int categoryId = -1, int subCategoryId = -1, DateTime? startDatePublished = null, DateTime? endDatePublished = null, DateTime? startDate = null, DateTime? endDate = null, string? common = "defaultValue", string? city= "defaultValue");
        public Task<List<LostAndFoundWithNameDTO>> GetAdsByUserId(int userId);
        public Task<LostAndFound> AddAd(LostAndFound lf, List<string> cities);
        public Task<LostAndFound> UpdateAd( LostAndFound lf,List<string> Cities,int adId);
        public Task SetPicture(int studentId, string fileName);
        public void sendEmail(int? categoryId);

        public Task UploadFile(int studentId, IFormFile userfile);
    }
}
