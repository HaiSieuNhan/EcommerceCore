using Ecommerce.Common.Infrastructure.ViewModel.Admin.ViewModel;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;
using Ecommerce.Common.Helpers;
using System.Linq;
using cloudscribe.Pagination.Models;

namespace Ecommerce.Service.Services
{
    public class ProductService : EcommerceServices<Product>,IProductSevice
    {
        private readonly IProductRepository _productReponsitory;
        private readonly IWebHostEnvironment _hostEnvironment;
        

        public ProductService(IProductRepository productReponsitory,IWebHostEnvironment hostEnvironment) : base(productReponsitory)
        {
            _productReponsitory = productReponsitory;
            _hostEnvironment = hostEnvironment;
        }

        public async Task UploadImageAsync(Product product)
        {
            ///
            //save image to wwwwroot/image
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
            string extension = Path.GetExtension(product.ImageFile.FileName);
            product.ImageName = fileName = fileName + extension;

            string path = Path.Combine(wwwRootPath + "/images/product/", fileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await product.ImageFile.CopyToAsync(fileStream);
            }
            ///
          
        }
        public async Task<ProductAdminViewModel> GetDetailsProductAdminViewModels(Guid id)
        {
            var product = await _productReponsitory.GetDetailsProductAdminViewModels(id);
            return product;
        }

        public async Task<List<ProductAdminViewModel>> GetListProduct(string order, string searchString/*, int pageNumber , int pageSize*/)
        {
            //int ExcludeRecords = (pageNumber * pageSize) - pageSize;
            var productlist = await _productReponsitory.GetProductAdminViewModels(order, searchString);

            //// var product = productlist.Skip(ExcludeRecords)
            ////                     .Take(pageSize).ToList();
            ////// var product = await _productReponsitory.GetByIdAsync(productId);
            //var result = new PagedResult<ProductAdminViewModel>
            //{
            //    Data =  productlist,
            //    TotalItems =productlist.Count(),
            //    PageNumber = pageNumber,
            //    PageSize = pageSize
            //};

            return productlist;
        }

        public async Task SaveChange(bool isSave)
        {
           await _productReponsitory.SaveChangesAsync(isSave);
        }
    }
}
