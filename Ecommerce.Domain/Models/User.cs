using Ecommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce.Domain.Models
{
    public class User : BaseModel
    {
        [Required]
        [StringLength(100)]
        public string Username { get; set; }
        public string Token { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Roles { get; set; }
        public bool IsConfirmation { get; set; }
        #region Relationship
        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Orders> Orders { get; set; }

        #endregion

    }
}
