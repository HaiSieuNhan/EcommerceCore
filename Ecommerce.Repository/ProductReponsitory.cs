using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.Domain;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class ProductReponsitory : BaseRepository<Product>, IProductReponsitory
    {
        public ProductReponsitory(EcommerceDbContext dbContext) : base(dbContext)
        {
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
