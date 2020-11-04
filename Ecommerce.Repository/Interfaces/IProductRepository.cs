using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Common.Infrastructure.ViewModel.Admin.ViewModel;
using Ecommerce.Domain.Models;

namespace Ecommerce.Repository.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<Product>> GetProductByCategoryIdAndOrderByView(Guid categoryId);
        Task<bool> GrowUpViewByProductId(Guid productId);
        //lay ra danh sach product 
        Task<List<ProductAdminViewModel>> GetProductAdminViewModels(string order, string searchString);
        Task<List<ProductAdminViewModel>> GetHotProductInWeek();

        //get details product
        Task<ProductAdminViewModel> GetDetailsProductAdminViewModels(Guid id);

    } 
   
}
