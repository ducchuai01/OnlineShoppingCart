using System;
using System.Collections.Generic;

namespace OnlineShoppingCart.Models
{
    public partial class wards
    {
        public wards()
        {
            Users = new HashSet<Users>();
        }

        public string code { get; set; }
        public string name { get; set; }
        public string name_en { get; set; }
        public string full_name { get; set; }
        public string full_name_en { get; set; }
        public string code_name { get; set; }
        public string district_code { get; set; }
        public int? administrative_unit_id { get; set; }

        public virtual administrative_units administrative_unit_ { get; set; }
        public virtual districts district_codeNavigation { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
