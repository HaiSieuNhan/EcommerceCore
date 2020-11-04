using Ecommerce.Common.Infrastructure.ViewModel.Admin.ViewModel;
using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Interface
{
    public interface IManufacturerServices:IServices<Manufacturer>
    {
        Task<List<ManufacturerAdminViewModel>> GetListManufacturerAdmin();
    }
}
