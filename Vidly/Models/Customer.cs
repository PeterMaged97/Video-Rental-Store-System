using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Customer
    {
        public int id { get; set; }

        [Display(Name = "Name")]
        [Required]
        public string name{ get; set; }

        public bool isSubscribed { get; set; }

        public MembershipType MembershipType{ get; set; }

        [Display(Name = "Membership Type")]
        public int MembershipTypeID { get; set; }

        [Column(TypeName = "Date")]
        [Display(Name = "Date of Birth")]
        [Min18IfMember]
        public DateTime? birthdate { get; set; }
    }
}