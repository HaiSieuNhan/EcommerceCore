using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Models
{
    public static class Role
    {
        public const string Admin = "Admin";
        public const string Staff = "Staff";
        public const string Guest = "Guest";
        public const string Customer = "Customer";
    }
}
