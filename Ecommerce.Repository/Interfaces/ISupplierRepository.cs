using Ecommerce.Common.Infrastructure.ViewModel.Admin;
using Ecommerce.Common.Infrastructure.ViewModel.Admin.ViewModel;
using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Interfaces
{
    public interface ISupplierRepository:IRepository<Supplier>
    {
        Task<List<SupplierAdminViewModel>> GetListSupplierAdminViewModel();
    }
}
