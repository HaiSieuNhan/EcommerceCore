using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Common.Infrastructure.ViewModel.Admin.ViewModel;
using Ecommerce.Domain;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(EcommerceDbContext dbContext) : base(dbContext)
        {
        }

        public Task<List<ProductAdminViewModel>> GetHotProductInWeek()
        {
            throw new NotImplementedException();
        }
        public async Task<List<ProductAdminViewModel>> GetProductAdminViewModels(string order, string searchString)
        {
            var query = (from p in DbContext.Products
                         join c in DbContext.Categories on p.CategoryId equals c.Id
                         join s in DbContext.Suppliers on p.SupplierId equals s.Id
                         join m in DbContext.Manufacturers on p.ManufacturerId equals m.Id
                         select new { p, c, s, m });
            //SearchString
            if (!String.IsNullOrEmpty(searchString))
            {
                query = query.Where(p => p.p.Name.Contains(searchString) || p.p.Keyword.Contains(searchString));
            }
            // sorting
            switch (order)
            {
                case "Name_Prduct_ASC":
                    query = query.OrderBy(p => p.p.Name);
                    break;
                case "Name_Prduct_DESC":
                    query = query.OrderByDescending(p => p.p.Name);
                    break;
                case "Price_Prduct_ASC":
                    query = query.OrderBy(p => p.p.Price);
                    break;
                case "Price_Prduct_DESC":
                    query = query.OrderByDescending(p => p.p.Price);
                    break;
            }
            var data = await query
            .Select(x => new ProductAdminViewModel()
            {
                Id = x.p.Id,
                Name = x.p.Name,
                CategoryName = x.c.Name,
                SupplierName = x.s.Name,
                Price = x.p.Price,
                Description = x.p.Description,
                PublicationDate = x.p.PublicationDate,
                Keyword = x.p.Keyword,
                Sku = x.p.Sku,
                Views = x.p.Views,
                ManufacturerName = x.m.Name,
                ImageName = x.p.ImageName,
            }).ToListAsync();
            return data;
        }
        public async Task<ProductAdminViewModel> GetDetailsProductAdminViewModels(Guid id)
        {

            var query = (from p in DbContext.Products
                         join c in DbContext.Categories on p.CategoryId equals c.Id
                         join s in DbContext.Suppliers on p.SupplierId equals s.Id
                         join m in DbContext.Manufacturers on p.ManufacturerId equals m.Id
                         select new { p, c, s, m });
            
            var data = await query
            .Where(x=>x.p.Id == id)
            .Select(x => new ProductAdminViewModel()
            {
                Id = x.p.Id,
                Name = x.p.Name,
                CategoryName = x.c.Name,
                SupplierName = x.s.Name,
                Price = x.p.Price,
                Description = x.p.Description,
                PublicationDate = x.p.PublicationDate,
                Keyword = x.p.Keyword,
                Sku = x.p.Sku,
                Views = x.p.Views,
                ManufacturerName = x.m.Name,
                ImageName = x.p.ImageName,
            }).FirstOrDefaultAsync();
            return data;
        }

        public async Task<List<Product>> GetProductByCategoryIdAndOrderByView(Guid categoryId)
        {

            var products = await DbContext.Products.Where(c => c.CategoryId == categoryId && c.Views >= 100).Take(100)
                .ToListAsync();
            return products;

            //sử dụng order by sắp xếp giảm dần rồi lấy 100 category lớn nhất
            //var products = await DbContext.Products.OrderByDescending(c => c.Views).Where(c => c.CategoryId == categoryId).Take(100)
            //    .ToListAsync();
            //return products;

        }

        public async Task<bool> GrowUpViewByProductId(Guid productId)
        {
            // get product by id
            var product = await GetByIdAsync(productId);
            if (product != null)
            {
                product.Views = product.Views + 1;
                await UpdateAsync(product);
                return true;
            }

            return false;
        }

    }
}
