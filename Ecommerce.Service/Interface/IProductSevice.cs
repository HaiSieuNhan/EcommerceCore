using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ecommerce.Common.Infrastructure.ViewModel.Admin.ViewModel;
using Ecommerce.Domain.Models;
using Ecommerce.Service.ViewModels;
using Ecommerce.Service.ViewModels.Admin.AddProduct;

namespace Ecommerce.Service.Interface
{
    public  interface IProductSevice : IServices<Product>
    {
        //Task<List<ProductViewModel>> GetProductByCategoryIdAndOrderByView(Guid categoryId);
        //Task<bool> GrowUpViewByProductId(Guid productId);

        //// Lấy ra các sản phẩm mới nhất (trong vòng 7 ngày)
        //Task<ProductViewModel> GetNewProduct();

        //// Lấy ra những sản phẩm hot trend (Lượt xem nhiều nhất và số lượng mua nhiều nhất)
        //Task<ProductViewModel> GetHotTrendProduct();

        //// Lấy ra những sản phẩm đang được giảm giá nhiếu nhất
        //Task<ProductViewModel> GetDiscountProduct();
        //// lấy ra thông tin sản phẩm
        //Task<ProductViewModel> GetProduct();
        Task<List<ProductAdminViewModel>> GetListProduct(string order, string searchString);
        Task<ProductAdminViewModel> GetDetailsProductAdminViewModels(Guid id);

        Task SaveChange(bool isSave);
        Task UploadImageAsync(Product product);
    }
}
