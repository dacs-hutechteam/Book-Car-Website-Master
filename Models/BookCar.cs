using System;
using System.ComponentModel.DataAnnotations;

namespace BookCarProjectMaster.Models
{
    public partial class BookCar
    {
        [Key]
        public int BookCarsId { get; set; }

        public DateTime DateBookCar { get; set; }

        public decimal TotalRental { get; set; }

        public DateTime? DateOfReceive { get; set; }

        public DateTime? DateReturn { get; set; }

        public bool? PaymentStatus { get; set; }

        [Required]
        [StringLength(60)]
        public string FullNameUser { get; set; }

        [Required]
        [StringLength(20)]
        public string CardIDUser { get; set; }

        [Required]
        [StringLength(128)]
        public string AddressUser { get; set; }

        [Required]
        [StringLength(12)]
        public string NumberPhoneUser { get; set; }

        [StringLength(128)]
        public string EmailUser { get; set; }

        public int? CarProductsId { get; set; }

        public virtual CarProduct CarProduct { get; set; }
    }
}
