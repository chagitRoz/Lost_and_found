using AutoMapper;
using DataAccess.DBModels;

namespace Lost_and_found
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDTO, User>().ReverseMap();
            CreateMap<User, UserDTO>();
            CreateMap<CategoryDTO, Category>().ReverseMap();
            CreateMap<Category, CategoryDTO>();
            CreateMap<SubCategoryDTO, SubCategory>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDTO>();
            CreateMap<CityDTO, City>().ReverseMap();
            CreateMap<City, CityDTO>();
            CreateMap<LostAndFoundDTO, LostAndFound>().ReverseMap();
            CreateMap<LostAndFound, LostAndFoundDTO>();
            CreateMap<LostAndFoundWithCitiesDTO, LostAndFound>().ReverseMap();
            CreateMap<LostAndFound, LostAndFoundWithCitiesDTO>();
        }
    }
}
