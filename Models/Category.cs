using System;
using System.Collections.Generic;

namespace OnlineShoppingCart.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Products>();
        }

        public string CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Descripton { get; set; }
        public string Image { get; set; }
        public byte[] Created_at { get; set; }
        public DateTime? Modified_at { get; set; }
        public DateTime? Delete_at { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
