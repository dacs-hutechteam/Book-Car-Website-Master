namespace BookCarProjectMaster.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GearBoxs")]
    public partial class GearBox
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GearBox()
        {
            CarProducts = new HashSet<CarProduct>();
        }

        [Key]
        public int GearBoxsId { get; set; }

        [Required]
        [StringLength(50)]
        public string NameGearBox { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarProduct> CarProducts { get; set; }
    }
}
