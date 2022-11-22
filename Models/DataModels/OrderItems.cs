using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingCart.Models.DataModels
{
	[Table("OrderItems")]
	public class OrderItems
	{
        [Key]
        [Required]
        [DisplayName("Order Items ID")]
        public int OrderItemID { get; set; }
        [Required]
        [DisplayName("Order")]
        public int OrderID { get; set; }
        [Required]
        [DisplayName("Items")]
        public int ProductID { get; set; }
        [DisplayName("Quantity")]
        public int Quantity { get; set; }
        public float Price { get; set; }

        public Orders Orders { get; set; }
        public Products Products { get; set; }

    }
}

