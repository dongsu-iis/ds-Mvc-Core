using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ds.NorthwindApp.Web.Models
{
    public partial class CustomerCustomerDemo
    {
        [Key]
        [StringLength(5)]
        public string CustomerID { get; set; }
        [Key]
        [StringLength(10)]
        public string CustomerTypeID { get; set; }

        [ForeignKey(nameof(CustomerID))]
        [InverseProperty(nameof(Customers.CustomerCustomerDemo))]
        public virtual Customers Customer { get; set; }
        [ForeignKey(nameof(CustomerTypeID))]
        [InverseProperty(nameof(CustomerDemographics.CustomerCustomerDemo))]
        public virtual CustomerDemographics CustomerType { get; set; }
    }
}
