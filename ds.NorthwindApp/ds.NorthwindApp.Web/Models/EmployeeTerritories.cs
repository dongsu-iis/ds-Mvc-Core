using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ds.NorthwindApp.Web.Models
{
    public partial class EmployeeTerritories
    {
        [Key]
        public int EmployeeID { get; set; }
        [Key]
        [StringLength(20)]
        public string TerritoryID { get; set; }

        [ForeignKey(nameof(EmployeeID))]
        [InverseProperty(nameof(Employees.EmployeeTerritories))]
        public virtual Employees Employee { get; set; }
        [ForeignKey(nameof(TerritoryID))]
        [InverseProperty(nameof(Territories.EmployeeTerritories))]
        public virtual Territories Territory { get; set; }
    }
}
