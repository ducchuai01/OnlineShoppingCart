using System;
using System.Collections.Generic;

namespace OnlineShoppingCart.Models
{
    public partial class Discount
    {
        public Discount()
        {
            Products = new HashSet<Products>();
        }

        public int DiscountID { get; set; }
        public string DiscountName { get; set; }
        public string Description { get; set; }
        public decimal? DiscountPercent { get; set; }
        public bool? Active { get; set; }
        public byte[] Created_at { get; set; }
        public DateTime? Modified_at { get; set; }
        public DateTime? Delete_at { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
