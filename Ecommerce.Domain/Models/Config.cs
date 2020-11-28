using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Models
{
    public class Config:BaseModel
    {

        public string Key { get; set; }
        public string Value { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public string GroupConfig { get; set; }
    }
}
