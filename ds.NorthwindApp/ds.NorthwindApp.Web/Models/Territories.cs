using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ds.NorthwindApp.Web.Models
{
    public partial class Territories
    {
        public Territories()
        {
            EmployeeTerritories = new HashSet<EmployeeTerritories>();
        }

        [Key]
        [StringLength(20)]
        public string TerritoryID { get; set; }
        [Required]
        [StringLength(50)]
        public string TerritoryDescription { get; set; }
        public int RegionID { get; set; }

        [ForeignKey(nameof(RegionID))]
        [InverseProperty("Territories")]
        public virtual Region Region { get; set; }
        [InverseProperty("Territory")]
        public virtual ICollection<EmployeeTerritories> EmployeeTerritories { get; set; }
    }
}
