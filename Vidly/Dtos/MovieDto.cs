using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Dtos
{
    public class MovieDto
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public DateTime releaseDate { get; set; }

        public GenreDto genre { get; set; }

        [Required]
        [Range(1, 200)]
        public int stock { get; set; }

        [Required]
        public int GenreID { get; set; }

        

    }
}