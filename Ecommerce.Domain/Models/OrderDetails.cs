using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecommerce.Domain.Models
{
    public class OrderDetails: BaseModel
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        #region RelationShip
        [ForeignKey("Orders")]
        public Guid OrderId { get; set; }
        public virtual TransactionHistory Orders { get; set; }
        [ForeignKey("Product")]
        public Guid ProductId { get; set; }
        public virtual Product Product  { get; set; }
        //[ForeignKey("TransactionHistory")]
        //public Guid TransactionHistoryId { get; set; }
        //public virtual TransactionHistory TransactionHistory { get; set; }

        #endregion
    }
}
