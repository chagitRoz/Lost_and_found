using AutoMapper;
using BussinesLogic.IService;
using DataAccess.DBModels;
using DataAccess.IRepository;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Service
{
    public class CityService: ICityService
    {
        ICityRepository CityRepository;
        IMapper mapper; 
        public CityService(ICityRepository CityRepository, IMapper mapper)
        {
            this.CityRepository = CityRepository;
            this.mapper = mapper;
        }

        public async Task<List<CityDTO>> GetAllCity()
        {

            List<City> city = await CityRepository.GetAllCity();
            List<CityDTO> cityDTO = new();
            foreach (var city1 in city)
            {
                cityDTO.Add(mapper.Map<CityDTO>(city1));
            }
            return cityDTO;

        }
    }
}
