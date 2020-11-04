using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Common.Infrastructure.ViewModel.Admin.ViewModel
{
    public class ManufacturerAdminViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string Website { get; set; }
        public string LogoFile { get; set; }
        public string ProductName { get; set; }
        public string SupplierName { get; set; }
        public string CategoryName { get; set; }
    }
}
