using Ecommerce.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class Cart:BaseModel
    {
        //public int Number { get; set; }
        //public decimal FeeAmount { get; set; }
        //public decimal VoucherAmount { get; set; }
        //public decimal TotalPrice { get; set; }
        //[StringLength(7)]
        //public string VoucherCode { get; set; }
        #region Property
        public int ShoppingNumber { get; set; }
        public decimal TotalPrice { get; set; }
        public ShoppingCartEnum CartStatus { get; set; }
        #endregion

        #region RelationShip
        //[ForeignKey("Promotion")]
        //public Guid PromotionId { get; set; }
        //public virtual Promotion Promotion { get; set; }
        //[ForeignKey("User")]
        //public Guid UserId { get; set; }
        //public virtual User User { get; set; }
        //public virtual ICollection<CardDetails> CardDetails{ get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        #endregion

    }
}
