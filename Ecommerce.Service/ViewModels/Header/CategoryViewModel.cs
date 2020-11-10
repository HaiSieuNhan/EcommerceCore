using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Service.ViewModels.Header
{
    public class CategoryViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Sort { get; set; }
        public bool IsDisplayHomePage { get; set; }

    }
}
