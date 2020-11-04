using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Common.Infrastructure.ViewModel.Common
{
    public class PaginationModel: PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 5;
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
    }
}
