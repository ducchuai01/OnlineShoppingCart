using System;
using System.Collections.Generic;

namespace OnlineShoppingCart.Models
{
    public partial class OrderItems
    {
        public int OrderItems1 { get; set; }
        public int? OrderDetailID { get; set; }
        public string ProductID { get; set; }
        public byte[] Created_at { get; set; }
        public DateTime? Modified_at { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }
        public virtual Products Product { get; set; }
    }
}
