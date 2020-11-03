using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MembershipType
    {
        public int id { get; set; }
        public byte discountRate{ get; set; }
        public byte durationInMonths { get; set; }
        public short signupFee { get; set; }
        public string name { get; set; }

        public static readonly int Unknown = 0;
        public static readonly int PayAsYouGo = 1;
    }
}