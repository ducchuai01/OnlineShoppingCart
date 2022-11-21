using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Models
{
    [Table("Discounts")]
    public class Discounts
    {
		[Key]
		[Required]
		[DisplayName("Discount ID")]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int DiscountID { get; set; }
		[DisplayName("Discount Name")]
		[Column(TypeName = "nvarchar(50)")]
		[StringLength(50)]
		public string DiscountName { get; set; }
		[DisplayName("Description")]
		[Column(TypeName = "nvarchar(255)")]
		[MaxLength]
		public int Description { get; set; }
		[DisplayName("Discount Percent")]
		public int DiscountPercent { get; set; }
		[DisplayName("Active")]
		public bool Active { get; set; }
		[DisplayName("Created At")]
		public DateTime Created_at { get; set; }
		[DisplayName("Deleted At")]
		public DateTime Delete_at { get; set; }
		public ICollection<Products> Products { get; set; }
	}
}

