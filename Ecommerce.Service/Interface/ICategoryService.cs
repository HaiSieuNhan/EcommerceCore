using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;
using Ecommerce.Service.Dto;
using Ecommerce.Service.Dto.Common;
using Ecommerce.Service.ViewModels.Header;

namespace Ecommerce.Service.Interface
{
    public interface ICategoryService : IServices<Category>
    {
        Task<ICollection<CategoryViewModel>> GetCategoryParrent();

        Task<CategoryViewModel> GetCategoryForHomepage();
        Task DeleteMultilCategoryitem(DeleteCategoryItem items);
        Task UpdateMultilCategoryitem(UpdateCategoryItem categoryItems);
        Task<QueryListResponse<CategoryDto>> SearchAndPagingCategory(QueryBase<BaseSearch> dto);
    }
}
