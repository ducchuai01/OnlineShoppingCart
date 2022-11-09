using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Models
{
    [Table("Categories")]
    public class Categories
    {
        [Key]
        [Required]
        [DisplayName("Category ID")]
        [StringLength(36)]
        public Guid CategoryID { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Category Name")]
        public string CategoryName { get; set; }
        [DisplayName("Descripton")]
        [MaxLength]
        public string Descripton { get; set; }
        [DisplayName("Image")]
        [MaxLength]
        public string Image { get; set; }
        [DisplayName("Status")]
        public bool Status { get; set; }
        [DisplayName("Created At")]
        public DateTime Created_at { get; set; }
        public ICollection<Products> Products { get; set; }
    }
}
