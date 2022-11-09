using System;
using System.Collections.Generic;

namespace OnlineShoppingCart.Models
{
    public partial class CartItems
    {
        public int CartItemID { get; set; }
        public string ProductID { get; set; }
        public int? SessionID { get; set; }
        public byte[] Created_at { get; set; }
        public DateTime? Modified_at { get; set; }

        public virtual Products Product { get; set; }
        public virtual ShoppingSession Session { get; set; }
    }
}
