using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Videostore.Models;

namespace Videostore.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; } //moze i so site properties posebno zavisi

        public string TitleCustomer
        {
            get
            {
              return  (Customer!= null && Customer.Id != 0) ? "Edit Customer": "New Customer";
            }
        }
    }
}