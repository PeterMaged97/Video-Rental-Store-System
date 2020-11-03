using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int id { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string name { get; set; }

        [Column(TypeName = "Date")]
        [Display(Name ="Release Date")]
        [Required]
        public DateTime releaseDate{ get; set; }

        [Display(Name ="Stock")]
        [Required]
        [Range(1, 200)]
        public int stock { get; set; }

        
        public Genre genre { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int GenreID { get; set; }

    }
}