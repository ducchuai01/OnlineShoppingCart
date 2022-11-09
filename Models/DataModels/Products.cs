using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Models
{
    [Table("Products")]
    public class Products
    {
        [Key]
		[Required]
		[DisplayName("Product ID")]
		[StringLength(36)]
		public string ProductID { get; set; }
		[Required]
		[DisplayName("Product Name")]
		[StringLength(100)]
		[Column(TypeName = "nvarchar(100)")]
		public string ProductName { get; set; }
		[Required]
		[DisplayName("Image")]
		[MaxLength]
		public string Image { get; set; }
		[DisplayName("Related Images")]
		[MaxLength]
		public string RelatedImages { get; set; }
		[DisplayName("Price")]
		public float Price { get; set; }
		[DisplayName("Quantity")]
		public int Quantity { get; set; }
		[DisplayName("Category ID")]
		[StringLength(36)]

		public string CategoryID { get; set; }
		public Categories Categories { get; set; }
		[DisplayName("Discount ID")]
		public int DiscountID { get; set; }
		public Discounts Discounts { get; set; }
		[DisplayName("Status")]
		public bool Status { get; set; }
		[DisplayName("Created At")]
		public DateTime Created_at { get; set; }
		[DisplayName("Deleted At")]
		public DateTime Deleted_at { get; set; }
	}
}
