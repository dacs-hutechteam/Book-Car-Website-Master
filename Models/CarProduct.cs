namespace BookCarProjectMaster.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CarProduct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CarProduct()
        {
            BookCars = new HashSet<BookCar>();
        }

        [Key]
        public int CarProductsId { get; set; }

        [Required]
        [StringLength(50)]
        public string ModelCar { get; set; }

        [StringLength(20)]
        public string CarColor { get; set; }

        public int? NumberOfSeats { get; set; }

        [StringLength(128)]
        public string ImageFont { get; set; }

        [StringLength(128)]
        public string ImageBack { get; set; }

        [StringLength(50)]
        public string Keyword { get; set; }

        public int NumberOfCars { get; set; }

        public string Info { get; set; }

        public bool? ActionProduct { get; set; }

        public decimal RentCost { get; set; }

        public bool CarProductStatus { get; set; }

        public int? CarCategoryId { get; set; }

        public int? FuelsId { get; set; }

        public int? GearBoxsId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BookCar> BookCars { get; set; }

        public virtual CarCategory CarCategory { get; set; }

        public virtual Fuel Fuel { get; set; }

        public virtual GearBox GearBox { get; set; }
    }
}
