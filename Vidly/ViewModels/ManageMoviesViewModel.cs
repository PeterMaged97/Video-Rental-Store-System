using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class ManageMoviesViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie movie { get; set; }
    }
}