using System;
using System.Collections.Generic;

namespace OnlineShoppingCart.Models
{
    public partial class administrative_units
    {
        public administrative_units()
        {
            districts = new HashSet<districts>();
            provinces = new HashSet<provinces>();
            wards = new HashSet<wards>();
        }

        public int id { get; set; }
        public string full_name { get; set; }
        public string full_name_en { get; set; }
        public string short_name { get; set; }
        public string short_name_en { get; set; }
        public string code_name { get; set; }
        public string code_name_en { get; set; }

        public virtual ICollection<districts> districts { get; set; }
        public virtual ICollection<provinces> provinces { get; set; }
        public virtual ICollection<wards> wards { get; set; }
    }
}
