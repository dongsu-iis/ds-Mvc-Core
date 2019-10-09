using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ds.NorthwindApp.Web.Models
{
    [Table("Order Details")]
    public partial class Order_Details
    {
        [Key]
        public int OrderID { get; set; }
        [Key]
        public int ProductID { get; set; }
        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }

        [ForeignKey(nameof(OrderID))]
        [InverseProperty(nameof(Orders.Order_Details))]
        public virtual Orders Order { get; set; }
        [ForeignKey(nameof(ProductID))]
        [InverseProperty(nameof(Products.Order_Details))]
        public virtual Products Product { get; set; }
    }
}
