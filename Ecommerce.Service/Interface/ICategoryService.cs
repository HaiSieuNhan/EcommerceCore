using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;
using Ecommerce.Service.ViewModels.Header;

namespace Ecommerce.Service.Interface
{
    public interface ICategoryService : IServices<Category>
    {
        Task<ICollection<CategoryViewModel>> GetCategoryParrent();

        Task<CategoryViewModel> GetCategoryForHomepage();
    }
}
