using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Common.Infrastructure.ViewModel.Web
{
    public class ProductHomepage
    {
        public IList<ProductHomepageAttributeViewModel> ProductHomepageAttributeViewModels{ get; set; }
        public string Name { get; set; }
    }
}
