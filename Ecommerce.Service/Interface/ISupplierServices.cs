using Ecommerce.Common.Infrastructure.ViewModel.Admin;
using Ecommerce.Common.Infrastructure.ViewModel.Admin.ViewModel;
using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Interface
{
    public interface ISupplierServices:IServices<Supplier>
    {
        Task<List<SupplierAdminViewModel>> GetListSupplierAdmin();
    }
}
