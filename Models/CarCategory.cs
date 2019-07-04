using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookCarProjectMaster.Models
{
    public partial class CarCategory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarCategory()
        {
            CarProducts = new HashSet<CarProduct>();
        }

        public int CarCategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string NameCarCategory { get; set; }

        public bool CarCategoryStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CarProduct> CarProducts { get; set; }
    }
}
