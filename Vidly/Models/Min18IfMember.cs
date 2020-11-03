using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18IfMember : ValidationAttribute
    {

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var customer = (Customer)validationContext.ObjectInstance;
            if(customer.MembershipTypeID == MembershipType.PayAsYouGo || customer.MembershipTypeID == MembershipType.Unknown)
            {
                return ValidationResult.Success;
            }

            if(customer.birthdate == null)
            {
                return new ValidationResult("Birthday is Required");
            }

            var age = DateTime.Now.Year - customer.birthdate.Value.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer must be at least 18 years old to have a membership");


        }

    }
}