using Ecommerce.Common.Infrastructure.ViewModel.Admin.ViewModel;
using Ecommerce.Domain;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;


using System.Collections.Generic;

using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class ManufacturerRepository : BaseRepository<Manufacturer>, IManufacturerRepository
    {
        public ManufacturerRepository(EcommerceDbContext dbContext) : base(dbContext)
        {
        }
        public async Task<List<ManufacturerAdminViewModel>> GetListManufacturerAdminViewModel()
        {
            //throw new NotImplementedException();
            var listmanufacturer = await (from p in DbContext.Products
                                          join c in DbContext.Categories on p.CategoryId equals c.Id
                                          join s in DbContext.Suppliers on p.SupplierId equals s.Id
                                          join m in DbContext.Manufacturers on p.ManufacturerId equals m.Id
                                          where p.IsDeleted == false
                                          select new ManufacturerAdminViewModel
                                          {
                                              Name = m.Name,
                                              Code = m.CodeName,
                                              Description = m.Description,
                                              Website  = m.Website,
                                              LogoFile = m.Logo,
                                              ProductName = p.Name,
                                              SupplierName = s.Name,
                                              CategoryName = c.Name
                                          }).ToListAsync();
            return listmanufacturer;
        }
    }
}
