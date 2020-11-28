using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ecommerce.Common.Infrastructure.Extensions;
using Ecommerce.Domain.Models;
using Ecommerce.Repository;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Dto;
using Ecommerce.Service.Dto.Common;
using Ecommerce.Service.Interface;
using Ecommerce.Service.ViewModels.Header;
using Microsoft.EntityFrameworkCore;

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

        public async Task DeleteMultilCategoryitem(DeleteCategoryItem items)
        {
            var categories = new List<Category>();
            foreach (var item in items.Items)
            {
                var category = _categoryRepository.GetById(item);
                if (categories != null)
                {
                    categories.Add(category);

                }
            }
            if (categories != null && categories.Any())
            {
                await _categoryRepository.DeleteMultiAsync(categories);
            }

        }
        public async Task UpdateMultilCategoryitem(UpdateCategoryItem categoryItems)
        {
            var categories = _categoryRepository.GetAll().Where(s => categoryItems.Items.Contains(s.Id)).ToList();
            if (categories != null && categories.Any())
            {
                categories.ForEach(s =>
                {
                    s.Status = categoryItems.Status;
                    s.UpdatedDate = categoryItems.UpdatedDate;
                });
                await _categoryRepository.UpdateMultiFielStatusAsync(categories);
            }

        }

        public async Task<QueryListResponse<CategoryDto>> SearchAndPagingCategory(QueryBase<BaseSearch> dto)
        {
            return new QueryListResponse<CategoryDto>
            {
                Count = await BuildActivityQueryable(dto).CountAsync(),
                Items = await FilterActivitys(dto)
            };
        }
        #region Private Method
        private  IQueryable<CategoryDto> BuildActivityQueryable(QueryBase<BaseSearch> search)
        {
            var query =  _categoryRepository.GetAllAsQueryable().Where(x => x.IsDeleted == false)
                            .Select(t => new CategoryDto
                            {
                                Name = t.Name,
                                Description = t.Description,
                                Sort = t.Sort,
                                IsDisplayHomePage = t.IsDisplayHomePage
                            });
            if (!string.IsNullOrEmpty(search.Filter.Search))
            {
                query = query.Where(p=>p.Name.Contains(search.Filter.Search));
            }
            return query;
        }
        private async Task<List<CategoryDto>> FilterActivitys(QueryBase<BaseSearch> searchModel)
        {
            var query = BuildActivityQueryable(searchModel);
            var orderBy = searchModel.OrderBy ?? "CreatedDate";
            query = EntityQueryFilterHelper.CreateSort<CategoryDto>(searchModel.Direction == SortType.Desc, orderBy)(query);
            query = EntityQueryFilterHelper.Page<CategoryDto>(searchModel.PageIndex, searchModel.PageSize)(query);
            return await query.ToListAsync();
        }
        #endregion
    }
}
