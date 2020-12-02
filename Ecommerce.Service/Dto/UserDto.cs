using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Service.Dto
{
    public class UserDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập họ tên")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string Username { get; set; }
        [EmailAddress(ErrorMessage = "Vui lòng nhập lại Email")]
        [Required(ErrorMessage = "Vui lòng nhập email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập số điện thoại")]
        public string Phone { get; set; }
        public Gender Gender { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập chọn ngày sinh")]
        public DateTime Birthday { get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        public string Password { get; set; }
        public string Role { get; set; }
        public string Avatar { get; set; }
        public string Address { get; set; }
    }
    public enum Gender
    {
        Male = 1,
        Female = 0
    }
}
