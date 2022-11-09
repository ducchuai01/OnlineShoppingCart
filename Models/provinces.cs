using System;
using System.Collections.Generic;

namespace OnlineShoppingCart.Models
{
    public partial class provinces
    {
        public provinces()
        {
            Users = new HashSet<Users>();
            districts = new HashSet<districts>();
        }

        public string code { get; set; }
        public string name { get; set; }
        public string name_en { get; set; }
        public string full_name { get; set; }
        public string full_name_en { get; set; }
        public string code_name { get; set; }
        public int? administrative_unit_id { get; set; }
        public int? administrative_region_id { get; set; }

        public virtual administrative_regions administrative_region_ { get; set; }
        public virtual administrative_units administrative_unit_ { get; set; }
        public virtual ICollection<Users> Users { get; set; }
        public virtual ICollection<districts> districts { get; set; }
    }
}
