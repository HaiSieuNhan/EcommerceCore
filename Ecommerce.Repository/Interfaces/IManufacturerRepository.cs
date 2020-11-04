using Ecommerce.Common.Infrastructure.ViewModel.Admin.ViewModel;
using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Repository.Interfaces
{
    public interface IManufacturerRepository :IRepository<Manufacturer>
    {
        Task<List<ManufacturerAdminViewModel>> GetListManufacturerAdminViewModel();
    }
}
