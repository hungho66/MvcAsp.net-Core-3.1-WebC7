using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.AspNetCore.Http;
using MovieAsp.Data;

namespace MovieAsp.Models
{
    public class Movie
    {
        [Key]
        public int ID { get; set; }
        [Display(Name = "Tiêu Đề")]
        [Required]
        [StringLength(200, MinimumLength = 3)]
        public string Title { get; set; }
        [Display(Name = "Tóm tắc")]
        [StringLength(int.MaxValue, MinimumLength = 3)]
        public string Summary { get; set; }
        [Display(Name = "Ngày phát hành")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}",
        ApplyFormatInEditMode = true)]
        [CheckDateGreaterThanTodayAttribute]
        public DateTime ReleaseDate { get; set; }

        [StringLength(10)]
        [Display(Name = "Thể loại")]
        [GenreAttribute]
        public string Genre { get; set; }
        [Display(Name = "Giá")]
        [Range(5000, double.MaxValue)]
        public decimal Price { get; set; }
        [Display(Name = "Xếp hạng")]
        [Range(1, 5)]
        public double Rated { get; set; }

        [ForeignKey("genreId ")]
        public Genre genre { get; set; }

        public String PicturePath { get; set; }
        [NotMapped]
        [Display(Name = "Hình ảnh")]
        public IFormFile PictureUpload { get; set; }

        public class CheckDateGreaterThanTodayAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext
            validationContext)
            {
                DateTime dt = (DateTime)value;
                if (dt >= DateTime.UtcNow)
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult(ErrorMessage ?? "Dữ liệu ngày phải lớn hơn ngày hôm nay");
            }
        }

        public class GenreAttribute : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
            {
                int genreID = int.Parse(value.ToString());
                var db = new MovieDBContext();
                if (db.Genres.Any(x => x.ID == genreID))
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult(
                ErrorMessage ?? "Genre khong ton tai");
            }
        }
    }
}
