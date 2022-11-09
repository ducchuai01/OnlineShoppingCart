using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShoppingCart.Models
{
    [Table("Administrative_regions")]
    public class Administrative_regions
    {
        [Key]
        [Required]
        public int id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(255)")]
        [StringLength(255)]
        public string name { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string name_en { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar(255)")]
        public string code_name_en { get; set; }

        public ICollection<Provinces> Provinces { get; set; }
    }
}
