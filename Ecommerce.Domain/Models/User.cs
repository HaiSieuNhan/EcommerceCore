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
        [MaxLength(256)]
        public string UserName { get; set; }
        [MaxLength(256)]
        public string FirstName { get; set; }
        [MaxLength(256)]
        public string LastName { get; set; }
        public DateTime LastLoginDate { get; set; }
        public byte[] PassWordHash { get; set; }
        public byte[] PassWordSalt { get; set; }


        #region RelationShip
        [ForeignKey("Role")]
        public Guid RoleId { get; set; }
        public virtual Role Role { get; set; }

        public ICollection<Point> Points { get; set; }
        public ICollection<ProductRating> ProductRatings { get; set; }
        public ICollection<UserProfile> UserProfiles { get; set; }
        public ICollection<TransactionHistory> Orders { get; set; }
        public ICollection<Cart> Carts { get; set; }
        public ICollection<TransactionHistory> TransactionHistories { get; set; }
        public ICollection<Comment> Comments { get; set; }

        #endregion

    }
}
