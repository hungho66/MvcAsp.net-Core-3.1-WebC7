using System;
using System.ComponentModel.DataAnnotations;

namespace MovieAsp.Models
{
    public class ShippingDetail
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Ten")]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Dia Chi")]
        [Required]
        public string Address { get; set; }

        [Display(Name = "Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Mobile")]
        [Required]
        public int Mobile { get; set; }
        [Display(Name = "Ngày giao")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString =
        "{0:yyyy-MM-dd}", ApplyFormatInEditMode =
        true)]
        public DateTime ReleaseDate { get; set; }
    }
}
