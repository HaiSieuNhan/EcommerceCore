using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Service.Dto.Common
{
    public class QueryListResponse<T>
    {
        public IEnumerable<T> Items { get; set; }

        public int Count { get; set; }
    }
}
