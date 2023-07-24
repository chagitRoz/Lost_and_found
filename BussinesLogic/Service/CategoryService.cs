using AutoMapper;
using BussinesLogic.IService;
using DataAccess.DBModels;
using DataAccess.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinesLogic.Service
{
    public class CategoryService : ICategoryService
    {
        IMapper _mapper;
        ICategoryRepository categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository, IMapper _mapper)
        {
            this.categoryRepository = categoryRepository;
            this._mapper = _mapper;
        }
        public async Task<List<CategoryDTO>> GetAllCategory()
        {
            List<Category> categoriesList = await categoryRepository.GetAllCategory();
            List<CategoryDTO> categoriesListDTO = new();
            foreach (var category in categoriesList)
            {
                 categoriesListDTO.Add(_mapper.Map<CategoryDTO>(category));
            }
            return categoriesListDTO;
        }

    }
}
