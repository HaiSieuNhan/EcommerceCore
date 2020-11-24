using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Service.Dto
{
    public  class UserLoginDto
    {
        [Required(ErrorMessage ="Vui Lòng nhập tên đăng nhập")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Vui Lòng nhập mật khẩu")]
        public string Password { get; set; }
    }
}
