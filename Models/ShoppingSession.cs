using System;
using System.Collections.Generic;

namespace OnlineShoppingCart.Models
{
    public partial class ShoppingSession
    {
        public ShoppingSession()
        {
            CartItems = new HashSet<CartItems>();
        }

        public int SessionID { get; set; }
        public string UserID { get; set; }
        public decimal Total { get; set; }
        public byte[] Created_at { get; set; }
        public DateTime? Modified_at { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<CartItems> CartItems { get; set; }
    }
}
