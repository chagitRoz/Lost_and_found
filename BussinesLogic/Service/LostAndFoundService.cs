using AutoMapper;
using BussinesLogic.IService;
using DataAccess.DBModels;
using DataAccess.IRepository;
using DataAccess.Repository;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Service
{
    public class LostAndFoundService : ILostAndFoundService
    {
        ILostAndFoundRepository lostAndFoundRepository;
        IMapper mapper;
        public LostAndFoundService(ILostAndFoundRepository lostAndFoundRepository, IMapper mapper)
        {
            this.lostAndFoundRepository = lostAndFoundRepository;
            this.mapper = mapper;
        }

        public async Task<List<LostAndFoundDTO>> GetAllLostsAndFounds()
        {
            List<LostAndFound> lostAndFound = await lostAndFoundRepository.GetAllLostsAndFounds();
            List<LostAndFoundDTO> lostAndFoundDTO = new();
            foreach (var lf in lostAndFound)
            {
                lostAndFoundDTO.Add(mapper.Map<LostAndFoundDTO>(lf));
            }
            return lostAndFoundDTO;
        }

        public async Task<List<LostAndFoundDTO>> GetByParams(int TypeId, int CategoryId)
        {
            List<LostAndFound> lostAndFound = await lostAndFoundRepository.GetByParams(TypeId, CategoryId);
            List<LostAndFoundDTO> lostAndFoundDTO = new();
            foreach (var lf in lostAndFound)
            {
                lostAndFoundDTO.Add(mapper.Map<LostAndFoundDTO>(lf));
            }
            return lostAndFoundDTO;
        }
        public async Task<List<LostAndFoundWithNameDTO>> GetByAdvancedSearch(int userId=-1,int typeId = -1, int categoryId = -1, int subCategoryId = -1, DateTime? startDatePublished = null, DateTime? endDatePublished = null, DateTime? startDate = null, DateTime? endDate = null, string? common = "defaultValue", string city = "defaultValue")
        {
            List<LostAndFoundWithNameDTO> lostAndFound = await lostAndFoundRepository.GetByAdvancedSearch(userId,typeId, categoryId, subCategoryId, startDatePublished, endDatePublished, startDate, endDate, common, city);
            //foreach (var lf in lostAndFound)
            //{
            //    lostAndFoundDTO.Add(mapper.Map<LostAndFoundDTO>(lf));
            //}
            //return lostAndFoundDTO;
            return lostAndFound;
        }

        public async Task<List<LostAndFoundWithNameDTO>> GetAdsByUserId(int userId)
        {
            List<LostAndFoundWithNameDTO> lostAndFound = await lostAndFoundRepository.GetAdsByUserId(userId);
            return lostAndFound;
        }
        public async Task<LostAndFoundWithCitiesDTO> AddAd(LostAndFoundWithCitiesDTO lf)
        {
            List<string> cities = lf.Cities;
            LostAndFound ad = mapper.Map<LostAndFound>(lf);
            LostAndFound add1 = await lostAndFoundRepository.AddAd(ad, cities);
            LostAndFoundWithCitiesDTO add2 = mapper.Map<LostAndFoundWithCitiesDTO>(add1);
            return add2;
        }

        public async Task<LostAndFoundWithCitiesDTO> UpdateAd(int adId,LostAndFoundWithCitiesDTO lf)
        {
            List<string> cities = lf.Cities;
            LostAndFound ad = mapper.Map<LostAndFound>(lf);
            LostAndFound add1 = await lostAndFoundRepository.UpdateAd(ad,cities,adId);
            LostAndFoundWithCitiesDTO add2 = mapper.Map<LostAndFoundWithCitiesDTO>(add1);
            return add2;
        }

        public async Task<List<LostAndFoundWithNameDTO>> GetAllLostsAndFounds2()
        {
            return await lostAndFoundRepository.GetAllLostsAndFounds2();
        }
        public Task SetPicture(int studentId, string fileName)
        {
            return lostAndFoundRepository.SetPicture(studentId, fileName);
        }
        public Task UploadFile(int studentId, IFormFile userfile)
        {
            return lostAndFoundRepository.UploadFile(studentId, userfile);
        }
    }
}
