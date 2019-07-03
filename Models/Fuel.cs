namespace BookCarProjectMaster.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Fuel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Fuel()
        {
            CarProducts = new HashSet<CarProduct>();
        }

        [Key]
        public int FuelsId { get; set; }

        [Required]
        [StringLength(50)]
        public string NameFuel { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarProduct> CarProducts { get; set; }
    }
}
