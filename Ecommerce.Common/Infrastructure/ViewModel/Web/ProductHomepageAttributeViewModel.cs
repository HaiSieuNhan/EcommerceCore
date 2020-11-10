using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Common.Infrastructure.ViewModel.Web
{
    public class ProductHomepageAttributeViewModel
    {
        public Guid Id { get; set; }
        public string UrlImage { get; set; }
        public decimal Price { get; set; }
        public decimal PriceSale { get; set; }
        public decimal PercentSale { get; set; }
    }
}
