﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class Supplier : BaseModel
    {
        [MaxLength(255)]
        [Required(ErrorMessage ="Vui lòng nhập tên nhà cung cấp")]
        public string Name { get; set; }
        [MaxLength(255)]
        public string CodeName { get; set; }
        [MaxLength(255)]
        [Required(ErrorMessage = "Vui lòng nhập Email")]
        public string Email { get; set; }
        [MaxLength(30)]
        [Required(ErrorMessage = "Vui lòng nhập Phone")]
        public string Phone { get; set; }
        [MaxLength(30)]
        public string Fax { get; set; }
        [MaxLength(255)]
        public string Address { get; set; }
        #region Relation
        public virtual ICollection<Product> Products { get; set; }
        #endregion
    }
}
