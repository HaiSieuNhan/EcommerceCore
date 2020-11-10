using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Service.ViewModels.Header
{
    public class SupplierViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
    }
}
