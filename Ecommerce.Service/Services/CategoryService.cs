using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Domain.Models;
using Ecommerce.Repository;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;
using Ecommerce.Service.ViewModels;

namespace Ecommerce.Service.Services
{
    public class CategoryService : EcommerceServices<Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        //private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
            //_mapper = mapper;
        }

        public Task<CategoryViewModel> GetCategoryForHomepage()
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<CategoryViewModel>> GetCategoryParrent()
        {
            //var category = await _categoryRepository.GetCategoryParrent();
            //return _mapper.Map<List<CategoryViewModel>>(category);
            throw new System.NotImplementedException();

        }

       
    }
}
