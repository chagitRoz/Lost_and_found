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
    public class SubCategoryService: ISubCategoryService
    {
        IMapper _mapper;
        ISubCategoryRepository subCategoryRepository;
        public SubCategoryService(ISubCategoryRepository subCategoryRepository, IMapper _mapper)
        {
            this.subCategoryRepository = subCategoryRepository;
            this._mapper = _mapper;
        }
        public async Task<List<SubCategoryDTO>> GetSubcategoryByCategoryId(int categoryid)
        {
            if (categoryid != -1)
            {
                List<SubCategory> subCategoriesList = await subCategoryRepository.GetSubcategoryByCategoryId(categoryid);

                List<SubCategoryDTO> subCategoriesListDTO = new();
                if (subCategoriesList != null)
                {
                    foreach (var subCategory in subCategoriesList)
                    {
                        subCategoriesListDTO.Add(_mapper.Map<SubCategoryDTO>(subCategory));
                    }
                    return subCategoriesListDTO;
                }
            }
            return null;
        }

    }
}
