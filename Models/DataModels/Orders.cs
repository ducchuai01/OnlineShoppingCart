using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineShoppingCart.Models.DataModels
{
    [Table("Orders")]
    public class Orders
	{
        [Key]
        [Required]
        [DisplayName("Order ID")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }
        [Required]
        [DisplayName("User")]
        [StringLength(36)]
        public Guid UserID { get; set; }

        public DateTime Created_at { get; set; }

        public Users Users { get; set; }

        public ICollection<OrderItems> OrderItems { get; set; }
    }
}

