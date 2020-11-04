using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Common.Infrastructure.ViewModel.Admin.ViewModel
{
    public class SupplierAdminViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }
    }
}
