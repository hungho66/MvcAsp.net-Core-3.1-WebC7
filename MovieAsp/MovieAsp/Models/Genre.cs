using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using MovieAsp.Data;

namespace MovieAsp.Models
{
    public class Genre
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Movie> Movies { get; set; }

        [NotMapped]
        public SelectList Genres { get; set; }

    }
}
