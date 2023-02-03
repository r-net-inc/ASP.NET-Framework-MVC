using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerDetailsViewModel
    {
        public Customer Customer { get; set; }

        public IEnumerable<Rental> Rentals { get; set; }
    }
}