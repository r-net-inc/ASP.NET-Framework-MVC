using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class MovieDetailsViewModel
    {
        public Movie Movie { get; set; }

        public IEnumerable<Rental> Rentals { get; set; }
    }
}