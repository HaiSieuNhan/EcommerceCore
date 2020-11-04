using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Common.Infrastructure.ViewModel.Admin.ViewModel
{
    public class ProductAdminViewModel
    {
        public Guid Id { get; set; }
        public string ManufacturerName { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public string UrlName { get; set; }
        public string Name { get; set; }
        public string Sku { get; set; }
        public DateTime PublicationDate { get; set; }
        public decimal Price { get; set; }
        public int Views { get; set; }
        public string Keyword { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public string ImageName { get; set; }
        
    }
}
