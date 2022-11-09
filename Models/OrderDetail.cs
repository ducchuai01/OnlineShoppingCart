using System;
using System.Collections.Generic;

namespace OnlineShoppingCart.Models
{
    public partial class OrderDetail
    {
        public OrderDetail()
        {
            OrderItems = new HashSet<OrderItems>();
            PaymentDetails = new HashSet<PaymentDetails>();
        }

        public int OrderDetailID { get; set; }
        public string UserID { get; set; }
        public decimal Total { get; set; }
        public byte[] Created_at { get; set; }
        public DateTime? Modified_at { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
        public virtual ICollection<PaymentDetails> PaymentDetails { get; set; }
    }
}
