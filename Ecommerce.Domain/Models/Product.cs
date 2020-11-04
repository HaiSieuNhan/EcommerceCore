using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class Product : BaseModel
    {
        #region Property

        [Required]
        [MaxLength(255)]
        public string UrlName { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Sku { get; set; }
        public DateTime PublicationDate { get; set; }
        [Required]
        public decimal Price { get; set; }

        public int Views { get; set; }
        [MaxLength(128)]
        public string Keyword { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string Description { get; set; }

        public  string ShortDescription { get; set; }

        public double Weight { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string ImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }


        #endregion

        #region Relation
        [DisplayName("Nhà sản xuất")]
        public Guid ManufacturerId { get; set; }
        public virtual Manufacturer Manufacturer { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public virtual Category Category { get; set; }

        [ForeignKey("Supplier")]
        public Guid SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual ICollection<CardDetails> CardDetails { get; set; }
        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
        public virtual ICollection<ProductStatus> ProductStatuses { get; set; }
        public virtual ICollection<PromotionProduct> PromotionProducts { get; set; }
        public virtual ICollection<ProductRating> ProductRatings { get; set; }
        public virtual ICollection<HistoryDetail> HistoryDetails { get; set; }
        #endregion
    }
}
