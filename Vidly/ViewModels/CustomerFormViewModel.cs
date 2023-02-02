using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public Customer Customer { get; set; }

        public IEnumerable<MembershipType> MembershipTypes { get; set; }

        public string CustomerFormTitle
        {
            get
            {
                return (Customer.Id != 0) ? "Edit Customer" : "New Customer";
            }
        }
    }
}