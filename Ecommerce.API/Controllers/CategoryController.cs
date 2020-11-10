using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Domain.Models;
using Ecommerce.Portal.Infrastructure.Extensions;
using Ecommerce.Service.Dto;
using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Ecommerce.Portal.Infrastructure.Wrappers;
using Ecommerce.Service.ViewModels.Header;

namespace Ecommerce.Portal.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        { 
            _categoryService = categoryService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all category items not condition
        /// </summary>
        /// <returns>list category</returns>
        [HttpGet("GetCategories")]
        public async Task<ApiResponse> GetCategories()
        {
            var categories = await _categoryService.GetAllAsync();
            if (categories != null && categories.Any())
            {
                var result =_mapper.Map<List<CategoryViewModel>>(categories);
                return new ApiResponse("All category items", result, 200);
            }

            return new ApiResponse("No item", null, 200);
        }

        // GET: api/Category/5
        [HttpGet("get-all-category")]
        public async Task<ICollection<CategoryViewModel>> GetCategoryParrent()
        {
            return await _categoryService.GetCategoryParrent();
        }
        [HttpGet("get-category-by-id/{id}")]
        public async Task<ApiResponse> GetCategoryById(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category != null)
            {
                var result = _mapper.Map<CategoryViewModel>(category);
                return new ApiResponse("All category Detail", result, 200);
            }
            return new ApiResponse("No item", null, 200);
        }
        [HttpDelete("delete-category-by-id/{id}")]
        public async Task<ApiResponse> DeleteCategory(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category != null)
            {
              await  _categoryService.DeleteAsync(category);
                return new ApiResponse("Removed Item", 200);
            }
            return new ApiResponse("Can't delete item", null, 200);
        }
        [HttpPost("create-or-edit-category")]
        public async Task<ApiResponse> CreateOrEditCategory(CategoryDto dto)
        {
            if (!ModelState.IsValid)
            {
                throw new ApiException(ModelState.AllErrors());
            }           
            // Case insert
            if (!dto.Id.HasValue)
            {
                var category = _mapper.Map<Category>(dto);
                category.UpdatedDate = null;
                await _categoryService.AddAsync(category);
                return new ApiResponse("New record has been created to the database", dto, 201);
            }

            var categoryOld = await _categoryService.GetByIdAsync(dto.Id.Value);
            if (categoryOld !=  null)
            {
                var newCategory =_mapper.Map(dto, categoryOld);
                newCategory.UpdatedDate = DateTime.Now;
                await _categoryService.UpdateAsync(newCategory);
                return new ApiResponse($"Record has been updated with id {dto.Id} to the database", dto, 201);
            }
            throw new ApiException($"Record with id: {dto.Id} does not exist.", 400);
        }
    
    }  
}
