using System;
using System.Collections.Generic;

namespace OnlineShoppingCart.Models
{
    public partial class Users
    {
        public Users()
        {
            FeedBack = new HashSet<FeedBack>();
            OrderDetail = new HashSet<OrderDetail>();
            ShoppingSession = new HashSet<ShoppingSession>();
        }

        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmployeeName { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string provinces_code { get; set; }
        public string districts_code { get; set; }
        public string wards_code { get; set; }
        public string Role { get; set; }
        public byte[] Created_at { get; set; }
        public DateTime? Modified_at { get; set; }
        public DateTime? Delete_at { get; set; }

        public virtual districts districts_codeNavigation { get; set; }
        public virtual provinces provinces_codeNavigation { get; set; }
        public virtual wards wards_codeNavigation { get; set; }
        public virtual ICollection<FeedBack> FeedBack { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
        public virtual ICollection<ShoppingSession> ShoppingSession { get; set; }
    }
}
