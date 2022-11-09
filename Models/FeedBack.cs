using System;
using System.Collections.Generic;

namespace OnlineShoppingCart.Models
{
    public partial class FeedBack
    {
        public int FeedBackID { get; set; }
        public string UserID { get; set; }
        public DateTime? DateSend { get; set; }
        public string Title { get; set; }
        public string Answer { get; set; }
        public byte[] Created_at { get; set; }
        public DateTime? Modified_at { get; set; }

        public virtual Users User { get; set; }
    }
}
