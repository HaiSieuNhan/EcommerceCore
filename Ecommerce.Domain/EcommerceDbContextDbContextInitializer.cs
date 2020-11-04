using System.Linq;
using System.Threading.Tasks;
using Ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Ecommerce.Domain
{
    public class EcommerceDbContextDbContextInitializer : IEcommerceDbContextDbContextInitializer
    {
        private readonly EcommerceDbContext _context;

        public EcommerceDbContextDbContextInitializer(EcommerceDbContext context)
        {
            _context = context;
        }

        public bool EnsureCreated()
        {
            return _context.Database.EnsureCreated();
        }

        public void Migrate()
        {
            _context.Database.Migrate();
        }

        public async Task Seed()
        {
            await SeedCategory(_context);
            await SeedSupplier(_context);
            await SeedManufacture(_context);
            await SeedProduct(_context);
        }
        #region Seed Data
        private async Task SeedManufacture(EcommerceDbContext context)
        {
            if (!context.Manufacturers.Any())
            {
                await context.AddAsync(new Manufacturer
                {
                    Name = "IPhone",
                    CodeName = "I-Phone"
                });
                await context.SaveChangesAsync();
            }
        }
        private async Task SeedCategory(EcommerceDbContext context)
        {
            if (!context.Categories.Any())
            {
                await context.AddAsync(new Category
                {
                    Name = "Điện Thoại - Máy Tính Bảng",
                    Description = "Điện Thoại và máy tính bảng các loại",
                    ParentId = null,
                });

                await context.AddAsync(new Category
                {
                    Name = "Laptop - Máy Tính",
                    Description = "Laptop và máy tính các loại",
                    ParentId = null,
                });
                await context.AddAsync(new Category
                {
                    Name = "Loa PC",
                    Description = "Loa PC các loại",
                    ParentId = null,
                });
                await context.AddAsync(new Category
                {
                    Name = "Điện lạnh",
                    Description = "Danh mục điện thoại, máy tính bảng",
                    ParentId = null
                });
                await context.SaveChangesAsync();
                var dt = await context.Categories.FirstOrDefaultAsync(x => x.Name == "Điện Thoại - Máy Tính Bảng");
                await context.AddAsync(new Category
                {
                    Name = "Iphone 9",
                    Description = "Điện Thoại và máy tính bảng các loại",
                    ParentId = dt.Id,
                });
                await context.AddAsync(new Category
                {
                    Name = "Iphone 13",
                    Description = "Điện Thoại và máy tính bảng các loại",
                    ParentId = dt.Id,
                });
                await context.SaveChangesAsync();
            }
        }
        private async Task SeedSupplier(EcommerceDbContext context) {
            if (!context.Suppliers.Any())
            {
                await context.Suppliers.AddAsync(new Supplier{ 
                     Name = "Tiki",
                     CodeName = "Tyky",
                     Phone = "0971909930",
                     Email = "daohai2000.hl@gmail.com",
                });
              await  context.SaveChangesAsync();
            }    
        }
        private async Task SeedProduct(EcommerceDbContext context)
        {
            if (!context.Products.Any())
            {
                var category = await context.Categories.FirstOrDefaultAsync(x => x.Name == "Iphone 9");
                var supplier = await context.Suppliers.FirstOrDefaultAsync(x => x.Name == "Tiki");
                var man = await context.Manufacturers.FirstOrDefaultAsync((x => x.Name == "IPhone"));
                context.Products.Add(new Product{ 
                    SupplierId = supplier.Id,
                    CategoryId = category.Id,
                    ManufacturerId = man.Id,
                    Name = "Iphone 9 Plus",
                    Sku = "SKu123",
                    Price = 9000,
                    Status = Ecommerce.Domain.Enums.Status.Active,
                    Views = 100,
                    UrlName = "fb.com/haisieunhan.ahihi"
                });
                context.Products.Add(new Product
                {
                    SupplierId = supplier.Id,
                    CategoryId = category.Id,
                    ManufacturerId = man.Id,
                    Name = "SamSung S9",
                    Price = 7000,
                    Sku = "SKu123",
                    Status = Ecommerce.Domain.Enums.Status.Active,
                    Views = 100,
                    UrlName = "fb.com/haisieunhan.ahihi"
                });
                context.Products.Add(new Product
                {
                    SupplierId = supplier.Id,
                    CategoryId = category.Id,
                    ManufacturerId = man.Id,
                    Name = "Xiaomi M2",
                    Price = 4000,
                    Sku = "SKu123",
                    Status = Ecommerce.Domain.Enums.Status.Active,
                    Views = 100,
                    UrlName = "fb.com/haisieunhan.ahihi"
                });
                context.Products.Add(new Product
                {
                    SupplierId = supplier.Id,
                    CategoryId = category.Id,
                    ManufacturerId = man.Id,
                    Name = "Iphone 12 Plus",
                    Sku = "SKu123",
                    Price = 29000,
                    Status = Ecommerce.Domain.Enums.Status.Active,
                    Views = 100,
                    UrlName = "fb.com/haisieunhan.ahihi"
                });
                context.Products.Add(new Product
                {
                    SupplierId = supplier.Id,
                    CategoryId = category.Id,
                    ManufacturerId = man.Id,
                    Name = "Google Pixel L2",
                    Price = 8000,
                    Sku = "SKu123",
                    Status = Ecommerce.Domain.Enums.Status.Active,
                    Views = 100,
                    UrlName = "fb.com/haisieunhan.ahihi"
                });
                context.Products.Add(new Product
                {
                    SupplierId = supplier.Id,
                    CategoryId = category.Id,
                    ManufacturerId = man.Id,
                    Name = "Nokia Lumia 520",
                    Price = 15000,
                    Sku = "SKu123",
                    Status = Ecommerce.Domain.Enums.Status.Active,
                    Views = 100,
                    UrlName = "fb.com/haisieunhan.ahihi"
                });
                context.Products.Add(new Product
                {
                    SupplierId = supplier.Id,
                    CategoryId = category.Id,
                    ManufacturerId = man.Id,
                    Name = "Nokia Lumia 920",
                    Price = 10000,
                    Sku = "SKu123",
                    Status = Ecommerce.Domain.Enums.Status.Active,
                    Views = 100,
                    UrlName = "fb.com/haisieunhan.ahihi"
                });
                context.Products.Add(new Product
                {
                    SupplierId = supplier.Id,
                    CategoryId = category.Id,
                    ManufacturerId = man.Id,
                    Name = "OnePlus X2",
                    Price = 18000,
                    Sku = "SKu123",
                    Status = Ecommerce.Domain.Enums.Status.Active,
                    Views = 100,
                    UrlName = "fb.com/haisieunhan.ahihi"
                });
                await context.SaveChangesAsync();
            }
        }
        #endregion
    }
}