using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Videostore.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)//odime so dva parametri ctor taka ke imaame pristap do drugite properties na modelot kako sto e memmbershipType 
        {
            var customer = (Customer)validationContext.ObjectInstance;//odime preku casting posto e object inaku sega ke imame pristap do site polinja na customer klasata a znaeme deka ni treba membershiptypeId za da ... 

            if (customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthdate == null)
                return new ValidationResult("Birthdate is required.");

            int age = DateTime.Today.Year - customer.Birthdate.Value.Year;//da ne ni bese napraven birthdate kako nullable nemase da stavime 'value'

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Must be 18 years old to go on membership.");
        }
    }
}