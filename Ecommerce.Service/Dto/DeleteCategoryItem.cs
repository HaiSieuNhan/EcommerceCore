using Ecommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Service.Dto
{
    public class DeleteCategoryItem
    {
        public List<Guid> Items { get; set; }
    }
    public class UpdateCategoryItem
    {
        public List<Guid> Items { get; set; }
        public Status Status { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
