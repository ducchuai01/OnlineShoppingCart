using System;
using System.Collections.Generic;

namespace OnlineShoppingCart.Models
{
    public partial class PaymentDetails
    {
        public int PaymentID { get; set; }
        public int? OrderDetailID { get; set; }
        public int Amount { get; set; }
        public string Provider { get; set; }
        public string Status { get; set; }
        public byte[] Created_at { get; set; }
        public DateTime? Modified_at { get; set; }

        public virtual OrderDetail OrderDetail { get; set; }
    }
}
