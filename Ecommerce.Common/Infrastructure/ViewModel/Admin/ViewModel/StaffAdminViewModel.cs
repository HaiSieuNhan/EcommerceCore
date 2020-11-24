using EcommerceCommon.Infrastructure.ViewModel.Admin;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Common.Infrastructure.ViewModel.Admin.ViewModel
{
    public class StaffAdminViewModel : BaseViewModel
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
    }
    public enum Gender
    {
        Male = 1,
        Female = 0
    }
}
