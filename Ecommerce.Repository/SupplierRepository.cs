using Ecommerce.Common.Infrastructure.ViewModel.Admin;
using Ecommerce.Common.Infrastructure.ViewModel.Admin.ViewModel;
using Ecommerce.Domain;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository
{
    public class SupplierRepository: BaseRepository<Supplier>, ISupplierRepository
    {
        public SupplierRepository(EcommerceDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<SupplierAdminViewModel>> GetListSupplierAdminViewModel()
        {
            var listSupplier = await (from p in DbContext.Products
                                      join c in DbContext.Categories on p.CategoryId equals c.Id
                                      join s in DbContext.Suppliers on p.SupplierId equals s.Id
                                      where p.IsDeleted == false
                                      select new SupplierAdminViewModel
                                      {
                                          Name = s.Name,
                                          Email = s.Email,
                                          Phone = s.Phone,
                                          Address = s.Address,
                                          ProductName = p.Name,
                                          Price = p.Price,
                                          CategoryName = c.Name
                                      }).ToListAsync();
            return listSupplier;
        }
    }
}
