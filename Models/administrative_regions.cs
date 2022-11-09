using System;
using System.Collections.Generic;

namespace OnlineShoppingCart.Models
{
    public partial class administrative_regions
    {
        public administrative_regions()
        {
            provinces = new HashSet<provinces>();
        }

        public int id { get; set; }
        public string name { get; set; }
        public string name_en { get; set; }
        public string code_name { get; set; }
        public string code_name_en { get; set; }

        public virtual ICollection<provinces> provinces { get; set; }
    }
}
