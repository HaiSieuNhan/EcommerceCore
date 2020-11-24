using Ecommerce.Common.Infrastructure.ViewModel.Admin.ViewModel;
using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Models
{
    public class UserProfile:BaseModel
    {
        [MaxLength(64)]
        [Required]
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public string Phone { get; set; }
        [EmailAddress(ErrorMessage = "Vui lòng nhập lại Email")]
        public string Email { get; set; }
        public string Address { get; set; }
        public string AvatarUrl { get; set; } = "default.png";
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
