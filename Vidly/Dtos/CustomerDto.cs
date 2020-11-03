using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        public bool isSubscribed { get; set; }

        public int MembershipTypeID { get; set; }

        public MembershipTypeDto MembershipType { get; set; }

        //[Min18IfMember]
        public DateTime? birthdate { get; set; }
    }
}