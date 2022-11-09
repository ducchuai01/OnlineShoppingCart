using System;
using System.Collections.Generic;

namespace OnlineShoppingCart.Models
{
    public partial class Products
    {
        public Products()
        {
            CartItems = new HashSet<CartItems>();
            OrderItems = new HashSet<OrderItems>();
        }

        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public string CategoryID { get; set; }
        public int? DiscountID { get; set; }
        public bool? Status { get; set; }
        public byte[] Created_at { get; set; }
        public DateTime? Modified_at { get; set; }
        public DateTime? Delete_at { get; set; }

        public virtual Category Category { get; set; }
        public virtual Discount Discount { get; set; }
        public virtual ICollection<CartItems> CartItems { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
