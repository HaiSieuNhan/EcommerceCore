using Ecommerce.Common.Infrastructure.ViewModel.Admin.ViewModel;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Interfaces;
using Ecommerce.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services
{
    public class ManufacturerServices : EcommerceServices<Manufacturer>, IManufacturerServices
    {
        private readonly IManufacturerRepository _manufacturerReponsitory;

        public ManufacturerServices(IManufacturerRepository manufacturerReponsitory) : base(manufacturerReponsitory)
        {
            _manufacturerReponsitory = manufacturerReponsitory;
        }

        public async Task<List<ManufacturerAdminViewModel>> GetListManufacturerAdmin()
        {
            return await _manufacturerReponsitory.GetListManufacturerAdminViewModel();
        }
    }
}
